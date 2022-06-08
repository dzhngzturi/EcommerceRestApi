using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.DTOs.ProductType.Validators;
using Ecommerce.Application.Errors;
using Ecommerce.Application.Features.ProductTypes.Requests.Commands;
using Ecommerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.ProductTypes.Handlers.Commands
{
    public class UpdateProductTypesCoammandHandler : IRequestHandler<UpdateProductTypesCoammand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductTypesCoammandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductTypesCoammand request, CancellationToken cancellationToken)
        {

            var validator = new UpdateProductTypeDtoValidator();
            var validatorResult = await validator.ValidateAsync(request.ProductTypeDto);

            if (validatorResult.IsValid == false)
                throw new ValidationException(validatorResult);

            var prodcutType = await _unitOfWork.Repository<ProductType>().GetByIdAsync(request.ProductTypeDto.Id);

            if (prodcutType is null)
                throw new NotFoundException(nameof(prodcutType), request.ProductTypeDto);

            _mapper.Map(request.ProductTypeDto, prodcutType);

            await _unitOfWork.Repository<ProductType>().Update(prodcutType);
            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}
