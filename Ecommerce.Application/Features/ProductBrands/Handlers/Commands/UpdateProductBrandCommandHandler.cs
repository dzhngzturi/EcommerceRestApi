using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.DTOs.ProductBrand;
using Ecommerce.Application.DTOs.ProductBrand.Validators;
using Ecommerce.Application.Errors;
using Ecommerce.Application.Features.ProductBrands.Requests.Commands;
using Ecommerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.ProductBrands.Handlers.Commands
{
    public class UpdateProductBrandCommandHandler : IRequestHandler<UpdateProductBrandCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
           _mapper = mapper;
           _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateProductBrandCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductBrandDtoValidator();
            var validatorResult = await validator.ValidateAsync(request.UpdateProductBrandDto);

            if (validatorResult.IsValid == false)
                throw new ValidationException(validatorResult);

            var productBrand = await _unitOfWork.Repository<ProductBrand>().GetByIdAsync(request.UpdateProductBrandDto.Id);

            if (productBrand == null)
                throw new NotFoundException(nameof(productBrand), request.UpdateProductBrandDto);

            _mapper.Map(request.UpdateProductBrandDto, productBrand);
            await _unitOfWork.Repository<ProductBrand>().Update(productBrand);
            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}
