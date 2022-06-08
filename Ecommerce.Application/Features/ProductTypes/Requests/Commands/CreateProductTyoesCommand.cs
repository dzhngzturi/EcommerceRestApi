using Ecommerce.Application.DTOs.ProductType;
using Ecommerce.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.ProductTypes.Requests.Commands
{
    public class CreateProductTyoesCommand : IRequest<BaseCommandResponse>
    {
        public CreateProductTypeDto CreateProductTypeDto { get; set; }
    }
}
