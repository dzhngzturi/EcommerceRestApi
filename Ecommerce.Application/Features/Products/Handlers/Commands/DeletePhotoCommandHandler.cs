using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.Contracts.Persistence.Services;
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
    public class DeletePhotoCommandHandler : IRequestHandler<DeletePhotoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photo;

        public DeletePhotoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IPhotoService photo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _photo = photo;
        }
        public async Task<Unit> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
        {

            var photo = await _unitOfWork.Repository<Photo>().GetByIdAsync(request.Id);
            if (photo == null)
                throw new NotFoundException(nameof(photo), request.Id);

            await _unitOfWork.Repository<Photo>().Delete(photo);
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
