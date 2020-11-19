﻿namespace DiseaseConfirmer.Web.ViewModels.Categories
{
    using AutoMapper;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortDescription =>
            this.Description?.Length > 50
             ? this.Description.Substring(0, 50) + "..."
            : this.Description;

        public string Url => $"/f/{this.Name?.Replace(' ', '-')}";
    }
}
