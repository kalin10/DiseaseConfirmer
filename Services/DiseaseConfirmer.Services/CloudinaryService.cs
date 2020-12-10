namespace DiseaseConfirmer.Services
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using DiseaseConfirmer.Common;
    using DiseaseConfirmer.Services.Contracts;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;
        private readonly string defaultProfilePicUrl = @"https://res.cloudinary.com/dhyskq1at/image/upload/v1607544995/samples/people/blank-profile-picture-973460_640_l6mh0h.png";

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public bool IsPictureFileValid(IFormFile pictureFile)
        {
            if (pictureFile == null)
            {
                return false;
            }

            string[] validImageTypes = new string[]
            {
                "image/x-png",
                "image/gif",
                "image/jpeg",
                "image/jpg",
                "image/png",
                "image/gif",
                "image/svg",
            };

            if (!validImageTypes.Contains(pictureFile.ContentType))
            {
                return false;
            }

            return true;
        }

        [System.Obsolete]
        public async Task<string> UploudPictureAsync(IFormFile file)
        {
            if (file == null || this.IsPictureFileValid(file) == false)
            {
                return this.defaultProfilePicUrl;
            }

            string url = " ";
            byte[] destinationImage;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                destinationImage = memoryStream.ToArray();
            }

            using (var destinationStream = new MemoryStream(destinationImage))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, destinationStream),
                };

                var uploadResult = await this.cloudinary.UploadAsync(uploadParams);

                url = uploadResult.Uri.AbsoluteUri;
            }

            //url = url.Replace(GlobalConstants.BaseProfilePicture, string.Empty);

            return url;
        }
    }
}
