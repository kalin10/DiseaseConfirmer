namespace DiseaseConfirmer.Web.ViewModels.Messages
{
    using System.Collections.Generic;

    public class ChatViewModel
    {
        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}
