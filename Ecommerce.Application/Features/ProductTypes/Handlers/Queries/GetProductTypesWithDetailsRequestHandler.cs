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

namespace Ecommerce.Application.Features.ProductTypess.Handlers.Queries
{
    public class GetProductTypesWithDetailsRequestHandler : IRequestHandler<GetProductTypesWithDetailsRequest, ProductTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductTypeRepository _productTypeRepository;

        public GetProductTypesWithDetailsRequestHandler(IMapper mapper, IProductTypeRepository productTypeRepository)
        {
            _mapper = mapper;
            _productTypeRepository = productTypeRepository;
        }

        public async Task<ProductTypeDto> Handle(GetProductTypesWithDetailsRequest request, CancellationToken cancellationToken)
        {
            var productType = await _productTypeRepository.GetByIdAsync(request.Id);
            return _mapper.Map<ProductTypeDto>(productType);
        }
    }
}
