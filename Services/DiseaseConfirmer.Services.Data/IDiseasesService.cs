namespace DiseaseConfirmer.Services.Data
{
    using System.Collections.Generic;

    public interface IDiseasesService
    {
        IEnumerable<T> GetAllByCategory<T>(string categoryName, int? count = null);

        T GetByName<T>(string name);
    }
}
