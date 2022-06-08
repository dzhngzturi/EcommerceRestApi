using Ecommerce.Application.DTOs.ProductBrand;
using Ecommerce.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.ProductBrands.Requests.Commands
{
    public class CreateProductBrandCommand : IRequest<BaseCommandResponse>
    {
        public CreateProductBrandDto CreateProductBrandDto { get; set; }
    }
}
