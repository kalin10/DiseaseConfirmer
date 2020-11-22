namespace DiseaseConfirmer.Web.ViewModels
{
    using System;

    public class PagingViewModel
    {
        public int CurrentPage { get; set; }

        public bool HasPreviousPage => this.CurrentPage > 1;

        public int PreviousPageNumber => this.CurrentPage - 1;

        public bool HasNextPage => this.CurrentPage < this.PagesCount;

        public int NextPageNumber => this.CurrentPage + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.InquiriesCount / this.ItemsPerPage);

        public int InquiriesCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}
