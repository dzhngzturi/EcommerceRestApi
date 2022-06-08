using AutoMapper;
using Ecommerce.Application.DTOs.Account;
using Ecommerce.Application.Models.Identity;
using Ecommerce.Identity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Identity.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region IdentityAddress
            CreateMap<Address, AddressDto>().ReverseMap();
            #endregion


        }
    }
}
