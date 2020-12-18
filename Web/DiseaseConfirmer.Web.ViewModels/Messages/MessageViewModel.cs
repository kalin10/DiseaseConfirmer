namespace DiseaseConfirmer.Web.ViewModels.Messages
{
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class MessageViewModel : IMapFrom<Message>
    {
        public string Text { get; set; }

        public string SenderUserName { get; set; }
    }
}
