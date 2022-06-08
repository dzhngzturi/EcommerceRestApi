using Ecommerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.ProductType.Validators
{
    public class CreateProductTypeDtoValidator : AbstractValidator<CreateProductTypeDto>
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public CreateProductTypeDtoValidator(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
            Include(new IProductTypeDtoValidator());
        }
    }
}
