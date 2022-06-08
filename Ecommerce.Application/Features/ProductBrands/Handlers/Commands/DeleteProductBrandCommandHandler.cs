using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.Errors;
using Ecommerce.Application.Features.ProductBrands.Requests.Commands;
using Ecommerce.Domain;
using MediatR;

namespace Ecommerce.Application.Features.ProductBrands.Handlers.Commands
{
    public class DeleteProductBrandCommandHandler : IRequestHandler<DeleteProductBrandCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProductBrandCommand request, CancellationToken cancellationToken)
        {
            var productBrand = await _unitOfWork.Repository<ProductBrand>().GetByIdAsync(request.Id);
           
            if (productBrand == null)
                throw new NotFoundException(nameof(productBrand), request.Id);

            await _unitOfWork.ProductBrandRepository.Delete(productBrand);
            await _unitOfWork.Complete();
            
            return Unit.Value;
        }
    }
}
