namespace DiseaseConfirmer.Services.Contracts
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        bool IsPictureFileValid(IFormFile pictureFile);

        Task<string> UploudPictureAsync(IFormFile file);
    }
}
