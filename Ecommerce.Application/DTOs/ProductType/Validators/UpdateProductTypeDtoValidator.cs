using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.ProductType.Validators
{
    public class UpdateProductTypeDtoValidator : AbstractValidator<UpdateProductTypeDto>
    {
        public UpdateProductTypeDtoValidator()
        {
            Include(new IProductTypeDtoValidator());
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
