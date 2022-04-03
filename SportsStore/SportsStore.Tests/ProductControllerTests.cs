using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
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
            var result = productController.List(null, 2).ViewData.Model as ProductsListViewModel;

            // assert
            Product[] productArray = result.Products.ToArray();
            Assert.True(productArray.Length == 2);
            Assert.Equal("P4", productArray[0].Name);
            Assert.Equal("P5", productArray[1].Name);
        }


        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product { ProductId = 1, Name ="P1"},
                new Product { ProductId = 2, Name ="P2"},
                new Product { ProductId = 3, Name ="P3"},
                new Product { ProductId = 4, Name ="P4"},
                new Product { ProductId = 5, Name ="P5"}
            }).AsQueryable<Product>());

            var productController = new ProductController(mock.Object) { PageSize = 3};

            // act
            var result = productController.List(null, 2).ViewData.Model as ProductsListViewModel;

            // assert
            var pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPage);
        }

        [Fact]
        public void Can_Filter_Products()
        {
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product { ProductId = 1, Name ="P1", Category = "Cat1"},
                new Product { ProductId = 2, Name ="P2", Category = "Cat2"},
                new Product { ProductId = 3, Name ="P3", Category = "Cat1"},
                new Product { ProductId = 4, Name ="P4", Category = "Cat2"},
                new Product { ProductId = 5, Name ="P5", Category = "Cat3"}
            }).AsQueryable<Product>());

            var productController = new ProductController(mock.Object) { PageSize = 3 };

            // act
            var result = (productController.List("Cat2", 1).ViewData.Model as ProductsListViewModel)
                .Products
                .ToArray();

            // assert
            Assert.Equal(2, result.Length);
            Assert.True(result[0].Name == "P2" && result[0].Category == "Cat2");
            Assert.True(result[1].Name == "P4" && result[1].Category == "Cat2");
        }
    }
}