namespace DiseaseConfirmer.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Models;

    public class DiseasesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Diseases.Any())
            {
                return;
            }

            var diseases = new List<(string Name, string Description, string Symptoms, string Тreatment, string Cause)>
            {
                ("Brain Tumor", "A brain tumor is a mass or growth of abnormal cells in your brain.", "Symptoms", "Тreatment", "Cause"),
                ("Leukemia", "Cancer that starts in the bone marrow.", "Symptoms", "Тreatment", "Cause"),
            };

            var tummorsCategory = dbContext.Categories.FirstOrDefault(x => x.Name == "Tumors");

            foreach (var disease in diseases)
            {
                await dbContext.Diseases.AddAsync(new Disease
                {
                    Name = disease.Name,
                    Description = disease.Description,
                    Symptoms = disease.Symptoms,
                    Cause = disease.Cause,
                    Тreatment = disease.Тreatment,
                    CategoryId = tummorsCategory.Id.ToString(),
                    Category = tummorsCategory,
                });
            }
        }
    }
}
