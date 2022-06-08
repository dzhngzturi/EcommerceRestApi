using Ecommerce.Application.DTOs.ProductBrand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.ProductBrands.Requests.Commands
{
    public class UpdateProductBrandCommand : IRequest<Unit>
    {
       public UpdateProductBrandDto UpdateProductBrandDto { get; set; }
    }
}
