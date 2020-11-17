﻿namespace DiseaseConfirmer.Web.ViewModels.Categories
{
    using AutoMapper;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url => $"/f/{this.Name?.Replace(' ', '-')}";
    }
}
