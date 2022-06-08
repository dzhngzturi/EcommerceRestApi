using AutoMapper;
using Ecommerce.Application.DTOs;
using Ecommerce.Application.DTOs.Product;
using Ecommerce.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Profiles
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            var photo = source.Photos.FirstOrDefault(x => x.IsMain);
            if (photo != null)
            {
                return _configuration["ApiUrl"] + photo.PictureUrl;
            }

            return _configuration["ApiUrl"] + "images/products/placeholder.png";
        }
    }
}
