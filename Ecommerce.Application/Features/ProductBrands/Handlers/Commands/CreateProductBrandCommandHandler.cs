using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.DTOs.ProductBrand.Validators;
using Ecommerce.Application.Features.ProductBrands.Requests.Commands;
using Ecommerce.Application.Responses;
using Ecommerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.ProductBrands.Handlers.Commands
{
    public class CreateProductBrandCommandHandler : IRequestHandler<CreateProductBrandCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse> Handle(CreateProductBrandCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateProductBrandDtoValidator(_unitOfWork.ProductBrandRepository);
            var validatorResult = await validator.ValidateAsync(request.CreateProductBrandDto);

            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            else
            {
                var productBrand = _mapper.Map<ProductBrand>(request.CreateProductBrandDto);

                productBrand = await _unitOfWork.Repository<ProductBrand>().Add(productBrand);
                await _unitOfWork.Complete();

                response.Success = true;
                response.Message = "Creation Successfull";
                response.Id = productBrand.Id;
            }

            return response;
        }
    }
}
