using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using SportsStore.Components;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SportsStore.Tests
{
    public class NavigationMenuComponentTests
    {
        [Fact]
        public void Can_Select_Category()
        {
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product { ProductId = 1, Name ="P1", Category = "Apples"},
                new Product { ProductId = 2, Name ="P2", Category = "Plums"},
                new Product { ProductId = 3, Name ="P3", Category = "Oranges"},
                new Product { ProductId = 4, Name ="P4", Category = "Apples"},
                new Product { ProductId = 5, Name ="P5", Category = "Oranges"}
            }).AsQueryable<Product>());

            var component = new NavigationMenuViewComponent(mock.Object);

            var result = ((IEnumerable<string>)(component.Invoke() as ViewViewComponentResult)
                .ViewData.Model)
                .ToArray();

            Assert.True(Enumerable
                .SequenceEqual(new string[] { "Apples" , "Oranges", "Plums" }, result));
        }
    }
}
