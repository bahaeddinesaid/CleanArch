using Application.Exceptions;
using Application.Features.Products.Requests.Commands;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handlers.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.Get(request.Id);

            if (product == null)
                throw new NotFoundException(nameof(product), request.Id);

            await _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
