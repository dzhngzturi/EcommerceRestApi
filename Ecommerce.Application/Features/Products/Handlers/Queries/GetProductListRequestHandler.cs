using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.Contracts.Persistence.Specification;
using Ecommerce.Application.DTOs.Product;
using Ecommerce.Application.Features.Products.Requests.Queries;
using Ecommerce.Application.Profiles;
using Ecommerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Handlers.Queries
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, Pagination<ProductToReturnDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductListRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Pagination<ProductToReturnDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams: request._productParams);
            var countSpec = new ProductWithFiltersForCountSpecifications(productParams: request._productParams);
            var totalItems = await _productRepository.CountAsync(countSpec);
            var products = await _productRepository.ListAsyncWithSpec(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

            return new Pagination<ProductToReturnDto>(request._productParams.PageIndex, request._productParams.PageSize,totalItems,data);
        }
    }
}
