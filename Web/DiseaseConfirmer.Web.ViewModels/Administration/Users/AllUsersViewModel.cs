namespace DiseaseConfirmer.Web.ViewModels.Administration.Users
{
    using System.Collections.Generic;

    public class AllUsersViewModel
    {
        public IEnumerable<UserInListViewModel> Users { get; set; }
    }
}
