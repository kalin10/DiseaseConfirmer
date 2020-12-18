namespace DiseaseConfirmer.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<(string Name, string Description)>
            {
                ("Ear Disorders", "Pain/Infection in the ear and the hearing process."),
                ("Genetic Disorders", "A genetic disorder is a disease caused in whole or in part by a change in the DNA sequence away from the normal sequence."),
                ("Epidemics", "An epidemic is the rapid spread of disease to a large number of people in a given population within a short period of time."),
                ("Gynaecologic Disorders", "Gynecologic diseases in general are diseases that involved the female reproductive track."),
                ("Skin Conditions", "A skin condition, also known as cutaneous condition, is any medical condition that affects the integumentary system—the organ system that encloses the body and includes skin, hair, nails, and related muscle and glands."),
                ("Tumors", "A tumor is an abnormal growth of cells that serves no purpose."),
            };

            foreach (var category in categories)
            {
                await dbContext.Categories.AddAsync(new Category
                {
                    Name = category.Name,
                    Description = category.Description,
                });
            }
        }
    }
}
