namespace DiseaseConfirmer.Web.ViewModels.Complaints
{
    using System.Collections.Generic;

    public class ComplaintsViewModel
    {
        public IEnumerable<IndexComplaintViewModel> Complaints { get; set; }
    }
}
