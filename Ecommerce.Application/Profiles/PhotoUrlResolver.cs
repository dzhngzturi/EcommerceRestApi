using AutoMapper;
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
    public class PhotoUrlResolver : IValueResolver<Photo, PhotoToReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public PhotoUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Photo source, PhotoToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _configuration["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}

