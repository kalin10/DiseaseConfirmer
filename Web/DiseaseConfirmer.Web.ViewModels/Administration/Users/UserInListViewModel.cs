namespace DiseaseConfirmer.Web.ViewModels.Administration.Users
{
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class UserInListViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string UserName { get; set; }
    }
}