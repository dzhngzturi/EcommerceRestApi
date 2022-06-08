using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.Errors;
using Ecommerce.Application.Features.Products.Requests.Commands;
using Ecommerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Handlers.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(request.Id);
            if (product == null)
                throw new NotFoundException(nameof(product), request.Id);

            await _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
