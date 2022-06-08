using Ecommerce.Application.Contracts.Persistence.Services;
using Ecommerce.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IHostingEnvironment _environment;

        public PhotoService(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<Photo> SaveToDiskAsync(IFormFile file)
        {
            var photo = new Photo();
            if (file.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(_environment.WebRootPath + "/images/products/", fileName);
                await using var fileStream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(fileStream);

                photo.FileName = fileName;
                photo.PictureUrl = "images/products/" + fileName;

                return photo;
            }

            return null;
        }

        public void DeleteFromDisk(Photo photo)
        {
            if (File.Exists(Path.Combine(_environment.WebRootPath + "/images/products/", photo.FileName)))
            {
                File.Delete(_environment.WebRootPath + "/images/products/" + photo.FileName);   
            }
        }
    }
}
