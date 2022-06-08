using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.Contracts.Persistence.Specification;
using Ecommerce.Application.DTOs.Product;
using Ecommerce.Application.Features.Products.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Handlers.Queries
{
    public class GetProductWithDetailsRequestHandler : IRequestHandler<GetProductWithDetailsRequest, ProductToReturnDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductWithDetailsRequestHandler(IMapper mapper, IProductRepository productRepository )
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductToReturnDto> Handle(GetProductWithDetailsRequest request, CancellationToken cancellationToken)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(request.Id);
            var product = await _productRepository.GetEntityWithSpec(spec);
            return _mapper.Map<ProductToReturnDto>(product);    
        }
    }
}
