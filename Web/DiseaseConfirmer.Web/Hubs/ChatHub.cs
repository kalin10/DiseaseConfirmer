namespace DiseaseConfirmer.Web.Hubs
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Common;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.ViewModels.Messages;
    using Ganss.XSS;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.SignalR;

    [Authorize(Roles = GlobalConstants.DoctorRoleName)]
    public class ChatHub : Hub
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMessagesService messagesService;

        public ChatHub(
            UserManager<ApplicationUser> userManager,
            IMessagesService messagesService)
        {
            this.userManager = userManager;
            this.messagesService = messagesService;
        }

        public async Task Send(string message)
        {
            var sanitizer = new HtmlSanitizer();
            var sanitizedMessage = sanitizer.Sanitize(message);

            if (string.IsNullOrEmpty(sanitizedMessage) || string.IsNullOrWhiteSpace(sanitizedMessage))
            {
                return;
            }

            var user = await this.userManager.GetUserAsync(this.Context.User);
            var userName = user.UserName;

            var addedMessage = await this.messagesService.Create(user.Id, sanitizedMessage);

            await this.Clients.User(user.Id).SendAsync(
                "NewMessage", sanitizedMessage, userName, true);

            await this.Clients.Others.SendAsync(
                "NewMessage", sanitizedMessage, userName, false);
        }
    }
}
