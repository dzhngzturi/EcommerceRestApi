using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.DTOs.Product.Validators;

namespace Ecommerce.Application.DTOs.Product
{
    public class ProductPhotoDto
    {
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new[] {".jpg",".png",".jpeg"})]
        public IFormFile Photo { get; set; }    
    }
}
