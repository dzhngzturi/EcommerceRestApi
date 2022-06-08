using Ecommerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.ProductBrand.Validators
{
    public class UpdateProductBrandDtoValidator : AbstractValidator<UpdateProductBrandDto>
    {

        public UpdateProductBrandDtoValidator()
        {
            Include(new IProductBrandDtoValidator());
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} must be present"); ;  
        }
    }
}
