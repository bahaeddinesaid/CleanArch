using Application.Interfaces.Repository;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Mocks
{
    public static class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Type = "Test 1",
                    Description = "Test 11"
                },
                new Product
                {
                    Id = 2,
                    Type = "Test 2",
                    Description = "Test 22"
                },
                new Product
                {
                    Id = 3,
                    Type = "Test 3",
                    Description = "Test 33"
                }
            };

            var mockRepo = new Mock<IProductRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(products);

            mockRepo.Setup(r => r.Add(It.IsAny<Product>())).ReturnsAsync((Product product) =>
            {
                products.Add(product);
                return product;
            });

            return mockRepo;

        }

    }
}
