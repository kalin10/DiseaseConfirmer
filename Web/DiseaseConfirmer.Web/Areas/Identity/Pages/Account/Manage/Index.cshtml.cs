namespace DiseaseConfirmer.Web.Areas.Identity.Pages.Account.Manage
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Common;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Data.Contracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUsersService usersService;
        private readonly ICareersInfoService careersInfoService;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUsersService usersService,
            ICareersInfoService careersInfoService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this.usersService = usersService;
            this.careersInfoService = careersInfoService;
        }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Workplace")]
            public string Workplace { get; set; }

            [Display(Name = "Degrees")]
            public string Degrees { get; set; }

            [Display(Name = "Experience")]
            public string Experience { get; set; }

            [Display(Name = "Awards")]
            public string Awards { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await this._userManager.GetUserNameAsync(user);
            var phoneNumber = await this._userManager.GetPhoneNumberAsync(user);

            string workplace = string.Empty;
            string degrees = string.Empty;
            string awards = string.Empty;
            string experience = string.Empty;

            if (this.User.IsInRole(GlobalConstants.DoctorRoleName))
            {
                workplace = await this.careersInfoService.GetWorkplaceAsync(user.Id);
                degrees = await this.careersInfoService.GetDegreesAsync(user.Id);
                awards = await this.careersInfoService.GetAwardsAsync(user.Id);
                experience = await this.careersInfoService.GetExperienceAsync(user.Id);
            }


            this.Username = userName;
            this.FirstName = await this.usersService.GetFirstNameByIdAsync(user.Id);
            this.LastName = await this.usersService.GetLastNameByIdAsync(user.Id);

            this.Input = new InputModel
            {
                PhoneNumber = phoneNumber,
            };

            if (this.User.IsInRole(GlobalConstants.DoctorRoleName))
            {
                this.Input.Workplace = workplace;
                this.Input.Degrees = degrees;
                this.Input.Awards = awards;
                this.Input.Experience = experience;
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await this._userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this._userManager.GetUserId(this.User)}'.");
            }

            await this.LoadAsync(user);

            if (this.User.IsInRole(GlobalConstants.DoctorRoleName))
            {
                this.Input.Workplace = user.CareerInfo.Workplace;
                this.Input.Awards = user.CareerInfo.Awards;
                this.Input.Degrees = user.CareerInfo.Degrees;
                this.Input.Experience = user.CareerInfo.Experience;
            }

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await this._userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this._userManager.GetUserId(this.User)}'.");
            }

            if (!this.ModelState.IsValid)
            {
                await this.LoadAsync(user);
                return this.Page();
            }

            var phoneNumber = await this._userManager.GetPhoneNumberAsync(user);

            string workplace = string.Empty;
            string degrees = string.Empty;
            string awards = string.Empty;
            string experience = string.Empty;

            if (this.User.IsInRole(GlobalConstants.DoctorRoleName))
            {
                workplace = await this.careersInfoService.GetWorkplaceAsync(user.Id);
                degrees = await this.careersInfoService.GetDegreesAsync(user.Id);
                awards = await this.careersInfoService.GetAwardsAsync(user.Id);
                experience = await this.careersInfoService.GetExperienceAsync(user.Id);

                if (this.Input.Workplace != workplace)
                {
                    await this.careersInfoService.ChangeWorkplaceAsync(user.Id, this.Input.Workplace);
                }

                if (this.Input.Degrees != degrees)
                {
                    await this.careersInfoService.ChangeDegreesAsync(user.Id, this.Input.Degrees);
                }

                if (this.Input.Awards != awards)
                {
                    await this.careersInfoService.ChangeAwardsAsync(user.Id, this.Input.Awards);
                }

                if (this.Input.Experience != experience)
                {
                    await this.careersInfoService.ChangeExperienceAsync(user.Id, this.Input.Experience);
                }
            }



            if (this.Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await this._userManager.SetPhoneNumberAsync(user, this.Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    this.StatusMessage = "Unexpected error when trying to set phone number.";
                    return this.RedirectToPage();
                }
            }

            await this._signInManager.RefreshSignInAsync(user);
            this.StatusMessage = "Your profile has been updated";
            return this.RedirectToPage();
        }
    }
}
