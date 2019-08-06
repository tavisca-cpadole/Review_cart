using AddToCart;
using System;
using System.Collections.Generic;
using Xunit;

namespace CartTests
{
    public class UnitTest
    {
        [Fact]
        public void Add_To_Empty_Cart_test()
        {
            CartItem cartItem = new CartItem();
            Product product1 = new Product("Apple",100);
            Product product2 = new Product("Banana",200);
            cartItem.AddItem(product1);
            cartItem.AddItem(product2);

            Dictionary<Product,int> dictionaryExpected = new Dictionary<Product, int>()
            {
                {product1,1 },
                { product2,1}
            };

            Assert.Equal(dictionaryExpected,cartItem.ItemList());
        }

        [Fact]
        public void Check_Total_Price_Without_Discount()
        {
            CartItem cartItem = new CartItem();
            Product product1 = new Product("Apple", 100);
            Product product2 = new Product("Banana", 200);
            cartItem.AddItem(product1);
            cartItem.AddItem(product2);

            double expected = 300;
            Cart cart = new Cart(cartItem,"");

            Assert.Equal(expected, cart.GetFinal());
        }

        [Fact]
        public void Check_Total_Price_With_Discount()
        {
            CartItem cartItem = new CartItem();
            Product product1 = new Product("Apple", 100);
            Product product2 = new Product("Banana", 200);
            cartItem.AddItem(product1);
            cartItem.AddItem(product2);
            cartItem.AddItem(product2);

            double expected = 250;
            Cart cart = new Cart(cartItem, "GET50");

            Assert.Equal(expected, cart.GetFinal());
        }
    }
}
