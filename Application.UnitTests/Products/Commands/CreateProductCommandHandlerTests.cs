using Application.DTOs.Product;
using Application.Features.Products.Handlers.Commands;
using Application.Features.Products.Requests.Commands;
using Application.Interfaces.Repository;
using Application.Mappings;
using Application.Responses;
using Application.UnitTests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Products.Commands
{
    public class CreateProductCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly ProductDto _productDto;
        private readonly CreateProductCommandHandler _handler;

        public CreateProductCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MainProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _handler = new CreateProductCommandHandler(_mockUow.Object, _mapper);


            _productDto = new ProductDto
            {
                Id = 5,
                Type = "type",
                Description = "Test Desc"
            };
        }

        [Fact]
        public async Task Valid_Product_Added()
        {
            var result = await _handler.Handle(new CreateProductCommand() { productDto = _productDto }, CancellationToken.None);

            var products = await _mockUow.Object.ProductRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();

            products.Count.ShouldBe(4);
        }

        [Fact]
        public async Task InValid_Product_Added()
        {
            _productDto.Id = -5;

            var result = await _handler.Handle(new CreateProductCommand() { productDto = _productDto }, CancellationToken.None);


            var leaveTypes = await _mockUow.Object.ProductRepository.GetAll();
            
            //! expected 4 not 3
            leaveTypes.Count.ShouldBe(3);

            result.ShouldBeOfType<BaseCommandResponse>();

        }

    }
}
