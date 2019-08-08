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
            Product product1 = new Product("Apple",100,"grocery");
            Product product2 = new Product("Banana",200, "grocery");
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
        public void Check_Total_Price_With_Category_Discount()
        {
            CartItem cartItem = new CartItem();
            Product product1 = new Product("Apple", 100, "grocery");
            Product product2 = new Product("Banana", 200, "grocery");
            cartItem.AddItem(product1);
            cartItem.AddItem(product2);

            DiscountFactory discountFactory = new DiscountFactory();
            IDiscount discount = discountFactory.DiscountType("product");


            double expected = 270;
            Cart cart = new Cart(cartItem,discount,"");

            Assert.Equal(expected, cart.GetFinalPrice());
        }

        [Fact]
        public void Check_Total_Price_With_Cart_Discount()
        {
            CartItem cartItem = new CartItem();
            Product product1 = new Product("Apple", 100, "grocery");
            Product product2 = new Product("Banana", 200, "grocery");
            cartItem.AddItem(product1);
            cartItem.AddItem(product2);
            cartItem.AddItem(product2);

            DiscountFactory discountFactory = new DiscountFactory();
            IDiscount discount = discountFactory.DiscountType("Cart");

            double expected = 250;
            Cart cart = new Cart(cartItem, discount,"GET50");

            Assert.Equal(expected, cart.GetFinalPrice());
        }
    }
}
