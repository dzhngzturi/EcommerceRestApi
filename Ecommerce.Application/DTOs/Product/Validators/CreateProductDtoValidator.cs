using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.Product.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 charecters");
            
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 100 charecters");

            RuleFor(x => x.Price).NotEmpty().WithMessage("{PropertyName} is required!")
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1")
                .LessThan(1000).WithMessage("{PropertyName} must be less then 1000");

        }
    }
}
