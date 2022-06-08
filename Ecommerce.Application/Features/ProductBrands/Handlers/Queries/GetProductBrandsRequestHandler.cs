using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.DTOs.ProductBrand;
using Ecommerce.Application.DTOs.ProductType;
using Ecommerce.Application.Features.ProductBrands.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.ProductBrands.Handlers.Queries
{
    public class GetProductBrandsRequestHandler : IRequestHandler<GetProductBrandsRequest, List<ProductBrandDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductBrandRepository _productBrandRepository;

        public GetProductBrandsRequestHandler(IMapper mapper, IProductBrandRepository productBrandRepository)
        {
            _mapper = mapper;
            _productBrandRepository = productBrandRepository;
        }
        public async Task<List<ProductBrandDto>> Handle(GetProductBrandsRequest request, CancellationToken cancellationToken)
        {
            var productType = await _productBrandRepository.ListAllAsync();
            return _mapper.Map<List<ProductBrandDto>>(productType);
        }
    }
}
