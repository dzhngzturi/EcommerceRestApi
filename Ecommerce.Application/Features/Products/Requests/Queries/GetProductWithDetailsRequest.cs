using Ecommerce.Application.DTOs.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Requests.Queries
{
    public class GetProductWithDetailsRequest : IRequest<ProductToReturnDto>
    {
        public int Id { get; set; }
    }
}
