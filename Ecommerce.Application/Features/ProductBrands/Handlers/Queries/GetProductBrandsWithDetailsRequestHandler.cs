using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.DTOs.ProductBrand;
using Ecommerce.Application.Features.ProductBrands.Requests.Queries;
using MediatR;

namespace Ecommerce.Application.Features.ProductBrands.Handlers.Queries
{
    public class GetProductBrandsWithDetailsRequestHandler : IRequestHandler<GetProductBrandsWithDetailsRequest, ProductBrandDto>
    {
        private readonly IProductBrandRepository _productBrandRepository;
        private readonly IMapper _mapper;

        public GetProductBrandsWithDetailsRequestHandler(IProductBrandRepository productBrandRepository , IMapper mapper)
        {
            _productBrandRepository = productBrandRepository;
            _mapper = mapper;
        }
        public async Task<ProductBrandDto> Handle(GetProductBrandsWithDetailsRequest request, CancellationToken cancellationToken)
        {
            var productBrand = await _productBrandRepository.GetByIdAsync(request.Id);
            return _mapper.Map<ProductBrandDto>(productBrand);
        }
    }
}
