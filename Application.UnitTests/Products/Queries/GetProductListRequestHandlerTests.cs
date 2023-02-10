using Application.DTOs.Product;
using Application.Features.Products.Handlers.Queries;
using Application.Features.Products.Requests.Queries;
using Application.Interfaces.Repository;
using Application.Mappings;
using Application.UnitTests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Products.Queries
{
    public class GetProductListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;

       // private readonly Mock<IProductRepository> _mockRepo;
        public GetProductListRequestHandlerTests()
        {
            //_mockRepo = MockProductRepository.GetProductRepository();
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MainProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetProductListTest()
        {
            var handler = new GetProductListRequestHandler(_mockUow.Object, _mapper);

            var result = await handler.Handle(new GetProductListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<ProductDto>>();

            result.Count.ShouldBe(3);
        }
    }
}
