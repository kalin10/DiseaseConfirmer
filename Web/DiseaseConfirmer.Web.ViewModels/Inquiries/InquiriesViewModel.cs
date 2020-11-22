namespace DiseaseConfirmer.Web.ViewModels.Inquiries
{
    using System.Collections;
    using System.Collections.Generic;

    public class InquiriesViewModel : PagingViewModel
    {
        public IEnumerable<IndexInquiryViewModel> Inqueries { get; set; }
    }
}
