using Ecommerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.ProductBrand.Validators
{
    public class IProductBrandDtoValidator : AbstractValidator<IProductBrandDto>
    {

        public IProductBrandDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required")
.NotNull().MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparsionValue} charecters");
        }
    }
}
