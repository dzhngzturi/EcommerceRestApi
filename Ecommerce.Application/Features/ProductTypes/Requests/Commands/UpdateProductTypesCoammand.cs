﻿using Ecommerce.Application.DTOs.ProductType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.ProductTypes.Requests.Commands
{
    public class UpdateProductTypesCoammand : IRequest<Unit>
    {
        public UpdateProductTypeDto  ProductTypeDto { get; set; }
    }
}
