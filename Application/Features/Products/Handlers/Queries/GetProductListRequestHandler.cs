using Application.DTOs.Product;
using Application.Features.Products.Requests.Queries;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handlers.Queries
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, List<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

//        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductListRequestHandler(
                        IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.GetAll();
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
