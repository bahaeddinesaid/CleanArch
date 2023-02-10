using Application.Interfaces.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockProductRepo = MockProductRepository.GetProductRepository();

            mockUow.Setup(r => r.ProductRepository).Returns(mockProductRepo.Object);

            return mockUow;
        }
    }
}
