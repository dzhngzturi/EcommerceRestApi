using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.ProductType.Validators
{
    public class IProductTypeDtoValidator : AbstractValidator<IProductTypeDto>
    {
        public IProductTypeDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required")
.NotNull().MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparsionValue} charecters");
        }

    }
}
