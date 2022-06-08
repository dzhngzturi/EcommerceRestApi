using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.DTOs.Product.Validators;
using Ecommerce.Application.Errors;
using Ecommerce.Application.Features.Products.Requests.Commands;
using Ecommerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(request.Id); 
            if (product is null)
                throw new NotFoundException(nameof(product), request.Id);

            if (request.UpdateProductDto != null)
            {
                var validator = new UpdateProductDtoValidator(_unitOfWork.ProductTypeRepository, _unitOfWork.ProductBrandRepository);
                var validationResult = await validator.ValidateAsync(request.UpdateProductDto);
                if (validationResult.IsValid == false)
                    throw new ValidationException(validationResult);

                _mapper.Map(request.UpdateProductDto, product);
                await _unitOfWork.Complete();
            }

            return Unit.Value;
        }
    }
}
