using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.Errors;
using Ecommerce.Application.Features.ProductTypes.Requests.Commands;
using Ecommerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.ProductTypes.Handlers.Commands
{
    public class DeleteProductTypesCoammandHandler : IRequestHandler<DeleteProductTypesCoammand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteProductTypesCoammandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductTypesCoammand request, CancellationToken cancellationToken)
        {
            var productType = await _unitOfWork.Repository<ProductType>().GetByIdAsync(request.Id);

            if (productType == null)
                throw new NotFoundException(nameof(productType), request.Id);

            await _unitOfWork.ProductTypeRepository.Delete(productType);
            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}
