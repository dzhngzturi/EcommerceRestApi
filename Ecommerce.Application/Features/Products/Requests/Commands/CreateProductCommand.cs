using Ecommerce.Application.DTOs.Product;
using Ecommerce.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Requests.Commands
{
    public class CreateProductCommand : IRequest<ProductToReturnDto>
    {
        public CreateProductDto CreateProductDto { get; set; }
    }
}
