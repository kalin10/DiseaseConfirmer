namespace DiseaseConfirmer.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Data.Seeding.Dtos;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class DiseasesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Diseases.Any())
            {
                return;
            }

            var diseases = JsonConvert.DeserializeObject<DiseaseDto[]>(File.ReadAllText(@"../../Data/DiseaseConfirmer.Data/Seeding/Data/Diseases.json"));

            foreach (var disease in diseases)
            {
                var tummorsCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == disease.CategoryId);

                await dbContext.Diseases.AddAsync(new Disease
                {
                    Name = disease.Name,
                    Description = disease.Description,
                    Symptoms = disease.Symptoms,
                    Cause = disease.Cause,
                    Тreatment = disease.Тreatment,
                    CategoryId = tummorsCategory.Id,
                    Category = tummorsCategory,
                });
            }
        }
    }
}
