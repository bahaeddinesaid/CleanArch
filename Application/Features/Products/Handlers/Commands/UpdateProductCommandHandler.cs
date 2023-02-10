using Application.DTOs.Product.Validators;
using Application.Exceptions;
using Application.Features.Products.Requests.Commands;
using Application.Interfaces.Repository;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
      //  private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductDtoValidator(_unitOfWork.ProductRepository);
            var validationResult = await validator.ValidateAsync(request.productDto);

            if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

            var product = await _unitOfWork.ProductRepository.Get(request.Id);

            
                _mapper.Map(request.productDto, product);

                await _unitOfWork.ProductRepository.Update(product);
                await _unitOfWork.Save();


            return Unit.Value;
        }
    }
}
