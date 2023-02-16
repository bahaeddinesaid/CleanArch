using Application.DTOs.Product.Validators;
using Application.Features.Products.Requests.Commands;
using Application.Interfaces.Repository;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Application.Features.Products.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateProductDtoValidator(_unitOfWork.ProductRepository );
           var validationResult = await validator.ValidateAsync(request.productDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                Log.Error("End Response");
                Log.Error($"End Response{response.Message}");

            }
            else
            {
                var product = _mapper.Map<Product>(request.productDto);

                product = await _unitOfWork.ProductRepository.Add(product);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Product Creation Successful";
                response.Id = product.Id;
                Log.Information($"End Response{response}");

            }


            return response;
        }
    }
}
