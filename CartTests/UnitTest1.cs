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
            Product product1 = new Product("Apple", 100, CategoryList.Grocery.ToString());
            Product product2 = new Product("Banana", 200, CategoryList.Grocery.ToString());
            cartItem.AddItem(product1);

            cartItem.AddItem(product2);

            Dictionary<Product, int> dictionaryExpected = new Dictionary<Product, int>()
            {
                {product1,1 },
                { product2,1}
            };

            Assert.Equal(dictionaryExpected, cartItem.ItemList());
        }

        [Fact]
        public void Check_Total_Price_With_Category_Discount()
        {
            CartItem cartItem = new CartItem();
            Product product1 = new Product("Apple", 100, CategoryList.Grocery.ToString());
            Product product2 = new Product("Banana", 200, CategoryList.Grocery.ToString());
            cartItem.AddItem(product1);
            cartItem.AddItem(product2);

            DiscountFactory discountFactory = new DiscountFactory();
            IDiscount discount = discountFactory.DiscountType("product");


            double expected = 270;
            Cart cart = new Cart(cartItem, discount, "");

            Assert.Equal(expected, cart.GetFinalPrice());
        }

        [Fact]
        public void Check_Total_Price_With_Cart_Discount()
        {
            CartItem cartItem = new CartItem();
            Product product1 = new Product("Apple", 100, CategoryList.Grocery.ToString());
            Product product2 = new Product("Banana", 200, CategoryList.Grocery.ToString());
            cartItem.AddItem(product1);
            cartItem.AddItem(product2);
            cartItem.AddItem(product2);

            DiscountFactory discountFactory = new DiscountFactory();
            IDiscount discount = discountFactory.DiscountType("Cart");

            double expected = 250;
            Cart cart = new Cart(cartItem, discount, "GET50");

            Assert.Equal(expected, cart.GetFinalPrice());
        }

        [Fact]
        public void Check_Add_To_CategoryDiscount_Method()
        {
            CategoryDiscount categoryDiscount = new CategoryDiscount();
            categoryDiscount.AddDiscount(CategoryList.Utensils.ToString(),5);

            Assert.Equal(5,categoryDiscount.GetDiscount(CategoryList.Utensils.ToString()));
        }

        [Fact]
        public void Check_If_Can_Update_Product_Discount_Dictionary()
        {
            CategoryDiscount categoryDiscount = new CategoryDiscount();
            categoryDiscount.UpdateDiscount(CategoryList.Grocery.ToString(),7);

            Assert.Equal(7,categoryDiscount.GetDiscount(CategoryList.Grocery.ToString()));
        }
    }
}
