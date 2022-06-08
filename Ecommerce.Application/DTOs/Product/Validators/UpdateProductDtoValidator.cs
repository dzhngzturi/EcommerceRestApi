using Ecommerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.Product.Validators
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IProductBrandRepository _productBrandRepository;

        public UpdateProductDtoValidator(IProductTypeRepository productTypeRepository, IProductBrandRepository productBrandRepository)
        {
            _productTypeRepository = productTypeRepository;
            _productBrandRepository = productBrandRepository;

            Include(new IProductDtoValidator(_productTypeRepository, _productBrandRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present.");
        }
    }
}
