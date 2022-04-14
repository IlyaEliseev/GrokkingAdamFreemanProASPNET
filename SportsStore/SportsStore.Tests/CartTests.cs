using SportsStore.Models;
using System.Linq;
using Xunit;

namespace SportsStore.Tests
{
    public class CartTests
    {
        [Fact]
        public void Can_Add_New_Lines()
        {
            // arrange
            var product1 = new Product { ProductId = 1, Name = "P1" };
            var product2 = new Product { ProductId = 2, Name = "P2" };

            var cart = new Cart();

            // act
            cart.AddItem(product1, 1);
            cart.AddItem(product2, 1);
            var resultCart = cart.Lines.ToArray(); 

            // assert
            Assert.Equal(2, resultCart.Length);
            Assert.Equal(product1, resultCart[0].Product);
            Assert.Equal(product2, resultCart[1].Product);
        }

        [Fact]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            // arrange
            var product1 = new Product { ProductId = 1, Name = "P1" };
            var product2 = new Product { ProductId = 2, Name = "P2" };

            var cart = new Cart();

            // act
            cart.AddItem(product1, 1);
            cart.AddItem(product2, 1);
            cart.AddItem(product2, 10);
            var resultCart = cart.Lines.OrderBy(x =>x.Product.ProductId).ToArray();

            // assert
            Assert.Equal(2, resultCart.Length);
            Assert.Equal(1, resultCart[0].Quantity);
            Assert.Equal(11, resultCart[1].Quantity);
        }

        [Fact]
        public void Can_Remove_Line()
        {
            // arrange
            var product1 = new Product { ProductId = 1, Name = "P1" };
            var product2 = new Product { ProductId = 2, Name = "P2" };
            var product3 = new Product { ProductId = 3, Name = "P3" };

            var cart = new Cart();

            // act
            cart.AddItem(product1, 1);
            cart.AddItem(product2, 3);
            cart.AddItem(product3, 5);
            cart.AddItem(product2, 1);

            cart.RemoveLine(product2);
            var resultCart = cart.Lines.OrderBy(x => x.Product.ProductId).ToArray();

            // assert
            Assert.Equal(0, cart.Lines.Where(x => x.Product == product2).Count());
            Assert.Equal(1, resultCart[0].Quantity);
            Assert.Equal(2, resultCart.Count());
        }

        [Fact]
        public void Can_Calculate_Cart_Total()
        {
            // arrange
            var product1 = new Product { ProductId = 1, Name = "P1", Price = 100M };
            var product2 = new Product { ProductId = 2, Name = "P2", Price = 50M };
            var product3 = new Product { ProductId = 3, Name = "P3", Price = 10M };

            var cart = new Cart();

            // act
            cart.AddItem(product1, 1);
            cart.AddItem(product2, 1);
            cart.AddItem(product3, 2);
            cart.AddItem(product1, 1);

            var resultSum = cart.ComputeTotalValue();

            // assert
            Assert.Equal(270, resultSum);
        }

        [Fact]
        public void Can_Clear_Contents()
        {
            // arrange
            var product1 = new Product { ProductId = 1, Name = "P1", Price = 100M };
            var product2 = new Product { ProductId = 2, Name = "P2", Price = 50M };
            var product3 = new Product { ProductId = 3, Name = "P3", Price = 10M };

            var cart = new Cart();

            // act
            cart.AddItem(product1, 1);
            cart.AddItem(product2, 1);
            cart.AddItem(product3, 2);
            cart.AddItem(product1, 1);

            cart.Clear();

            // assert
            Assert.Equal(0, cart.Lines.Count());
        }
    }
}
