using Ecommerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.Product.Validators
{
    public class IProductDtoValidator : AbstractValidator<IProductDto>
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IProductBrandRepository _productBrandRepository;

        public IProductDtoValidator(IProductTypeRepository productTypeRepository,IProductBrandRepository productBrandRepository)
        {
            _productTypeRepository = productTypeRepository;
            _productBrandRepository = productBrandRepository;

            RuleFor(p => p.ProductTypeId).GreaterThan(0).MustAsync(async (id, token) =>
            {
                var producTypetExist = await _productTypeRepository.Exist(id);
                return producTypetExist;
            }).WithMessage("{PropertyName} does not exist!");

            RuleFor(p => p.ProductBrandId).GreaterThan(0).MustAsync(async (id, token) =>
            {
                var producBrandtExist = await _productBrandRepository.Exist(id);
                return producBrandtExist;
            }).WithMessage("{PropertyName} does not exist!");
        }
    }
}
