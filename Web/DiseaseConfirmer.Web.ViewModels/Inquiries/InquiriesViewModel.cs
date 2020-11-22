namespace DiseaseConfirmer.Web.ViewModels.Inquiries
{
    using System.Collections;
    using System.Collections.Generic;

    public class InquiriesViewModel
    {
        public IEnumerable<IndexInquiryViewModel> Inqueries { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }
    }
}
