using Ecommerce.Application.Contracts.Persistence.Specification;
using Ecommerce.Application.DTOs.Product;
using Ecommerce.Application.Profiles;
using Ecommerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Requests.Queries
{
    public class GetProductListRequest : IRequest<Pagination<ProductToReturnDto>>
    {
        public ProductSpecParams _productParams;

        public GetProductListRequest(ProductSpecParams productParams)
        {
            _productParams = productParams;
        }

    }
}
