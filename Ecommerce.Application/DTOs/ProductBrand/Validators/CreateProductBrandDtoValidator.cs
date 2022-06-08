using Ecommerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.ProductBrand.Validators
{
    public class CreateProductBrandDtoValidator : AbstractValidator<CreateProductBrandDto>
    {
        private readonly IProductBrandRepository _productBrandRepository;

        public CreateProductBrandDtoValidator(IProductBrandRepository productBrandRepository)
        {
            _productBrandRepository = productBrandRepository;
            Include(new IProductBrandDtoValidator());
        }
    }
}
