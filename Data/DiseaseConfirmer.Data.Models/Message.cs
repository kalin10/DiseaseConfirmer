namespace DiseaseConfirmer.Data.Models
{
    using DiseaseConfirmer.Data.Common.Models;

    public class Message : BaseDeletableModel<int>
    {
        public string Text { get; set; }

        public string SenderId { get; set; }

        public ApplicationUser Sender { get; set; }
    }
}
