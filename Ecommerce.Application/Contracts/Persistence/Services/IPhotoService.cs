using Ecommerce.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts.Persistence.Services
{
    public interface IPhotoService
    {
        Task<Photo> SaveToDiskAsync(IFormFile photo);
        void DeleteFromDisk(Photo photo);
    }
}
