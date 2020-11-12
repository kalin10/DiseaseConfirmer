namespace DiseaseConfirmer.Web.ViewModels.Categories
{
    public class CategoryViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url => $"/f/{this.Name.Replace(' ', '-')}";
    }
}
