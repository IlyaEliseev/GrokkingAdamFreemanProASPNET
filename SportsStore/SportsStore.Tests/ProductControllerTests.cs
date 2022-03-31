using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SportsStore.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            // arrange
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product { ProductId = 1, Name ="P1"},
                new Product { ProductId = 2, Name ="P2"},
                new Product { ProductId = 3, Name ="P3"},
                new Product { ProductId = 4, Name ="P4"},
                new Product { ProductId = 5, Name ="P5"}
            }).AsQueryable<Product>());

            var productController = new ProductController(mock.Object);
            productController.PageSize = 3;

            // act
            IEnumerable<Product> result = productController.List(2).ViewData.Model as IEnumerable<Product>;

            // assert

            Product[] productArray = result.ToArray();

            Assert.True(productArray.Length == 2);
            Assert.Equal("P4", productArray[0].Name);
            Assert.Equal("P5", productArray[1].Name);
        }
    }
}