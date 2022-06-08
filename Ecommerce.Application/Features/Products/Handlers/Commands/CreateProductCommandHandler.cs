using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.DTOs.Product;
using Ecommerce.Application.DTOs.Product.Validators;
using Ecommerce.Application.Errors;
using Ecommerce.Application.Features.Products.Requests.Commands;
using Ecommerce.Application.Responses;
using Ecommerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductToReturnDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductToReturnDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<CreateProductDto, Product>(request.CreateProductDto);
            await _unitOfWork.Repository<Product>().Add(product);
            
            var result = await _unitOfWork.Complete();

            if (result != 0) 
                return _mapper.Map<Product, ProductToReturnDto>(product);

            return null;
        }




    }
}
