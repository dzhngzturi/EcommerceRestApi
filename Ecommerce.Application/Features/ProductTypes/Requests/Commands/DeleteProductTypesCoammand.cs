using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.ProductTypes.Requests.Commands
{
    public class DeleteProductTypesCoammand : IRequest
    {
        public int Id { get; set; }
    }
}
