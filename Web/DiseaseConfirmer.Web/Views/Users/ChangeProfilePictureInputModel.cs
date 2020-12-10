namespace DiseaseConfirmer.Web.Views.Users
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class ChangeProfilePictureInputModel
    {
        [Required(ErrorMessage = "Please upload picture!")]
        public IFormFile ProfilePicture { get; set; }

        public string UserId { get; set; }
    }
}
