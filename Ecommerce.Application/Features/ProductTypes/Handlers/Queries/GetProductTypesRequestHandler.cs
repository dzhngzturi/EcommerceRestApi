using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.DTOs.ProductType;
using Ecommerce.Application.Features.ProductTypes.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.ProductTypes.Handlers.Queries
{
    public class GetProductTypesRequestHandler : IRequestHandler<GetProductTypesRequest, List<ProductTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductTypeRepository _productTypeRepository;

        public GetProductTypesRequestHandler(IMapper mapper, IProductTypeRepository productTypeRepository)
        {
            _mapper = mapper;
            _productTypeRepository = productTypeRepository;
        }
        public async Task<List<ProductTypeDto>> Handle(GetProductTypesRequest request, CancellationToken cancellationToken)
        {
            var productType = await _productTypeRepository.ListAllAsync();
            return _mapper.Map<List<ProductTypeDto>>(productType);
        }
    }
}
