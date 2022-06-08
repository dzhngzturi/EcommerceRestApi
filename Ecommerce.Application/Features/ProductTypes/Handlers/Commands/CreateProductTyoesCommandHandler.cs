using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.DTOs.ProductType.Validators;
using Ecommerce.Application.Features.ProductTypes.Requests.Commands;
using Ecommerce.Application.Responses;
using Ecommerce.Domain;
using MediatR;

namespace Ecommerce.Application.Features.ProductTypes.Handlers.Commands
{
    public class CreateProductTyoesCommandHandler : IRequestHandler<CreateProductTyoesCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductTyoesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateProductTyoesCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateProductTypeDtoValidator(_unitOfWork.ProductTypeRepository);
            var validatorResult = await validator.ValidateAsync(request.CreateProductTypeDto);
           
            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var productType = _mapper.Map<ProductType>(request.CreateProductTypeDto);

                productType = await _unitOfWork.Repository<ProductType>().Add(productType);
                await _unitOfWork.Complete();

                response.Success = true;
                response.Message = "Creation is succesfull";
                response.Id = productType.Id; 
            }

            return response;
        }
    }
}
