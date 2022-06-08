using Ecommerce.Application.DTOs.ProductBrand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.ProductBrands.Requests.Queries
{
    public class GetProductBrandsWithDetailsRequest : IRequest<ProductBrandDto>
    {
        public int Id { get; set; }
    }
}
