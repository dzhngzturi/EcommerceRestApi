﻿using Ecommerce.Application.DTOs.ProductType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.ProductTypes.Requests.Queries
{
    public class GetProductTypesWithDetailsRequest : IRequest<ProductTypeDto>
    {
        public int Id { get; set; }
    }
}
