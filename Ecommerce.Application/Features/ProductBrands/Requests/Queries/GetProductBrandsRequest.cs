using Ecommerce.Application.DTOs.ProductBrand;
using Ecommerce.Application.DTOs.ProductType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.ProductBrands.Requests.Queries
{
    public class GetProductBrandsRequest : IRequest<List<ProductBrandDto>>
    {

    }
}
