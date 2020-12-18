namespace DiseaseConfirmer.Web.Areas.Doctors.Controllers
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.ViewModels.Messages;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class MessagesController : DoctorsController
    {
        private readonly IMessagesService messagesService;

        public MessagesController(IMessagesService messagesService)
        {
            this.messagesService = messagesService;
        }

        [Authorize]
        public async Task<IActionResult> Chat()
        {
            var viewModel = new ChatViewModel();
            viewModel.Messages = await this.messagesService.MessagesFromToday<MessageViewModel>();

            return this.View(viewModel);
        }
    }
}
