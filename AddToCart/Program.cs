﻿using System;
using System.Collections.Generic;

namespace AddToCart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Product {

        public Product(string name,double price,Category category) {
            this.Name = name;
            this.Price = price;
            this.Category = category;
        }

        public string Name { get; }
        public double Price { get; }

        public Category Category { get; }
    }

    public class CartItem {
        private Dictionary<Product, int> _cartItems = new Dictionary<Product, int>();

        public Dictionary<Product, int> ItemList()
        {
            return _cartItems;
        }
        public void AddItem(Product product)
        {
            if (_cartItems.ContainsKey(product))
            {
                _cartItems[product] += 1;
            }
            else
            {
                _cartItems[product] = 1;
            }
        }

        public double GetPrice(Product product)
        {
            try
            {
                return _cartItems[product] * product.Price - (_cartItems[product] * product.Price) * (double)product.Category / 100;
            }
            catch (Exception)
            {
                throw new EmptyCartException();
            }
        }


    }


    [Serializable]
    class EmptyCartException : Exception
    {

        public EmptyCartException()
            : base(String.Format("Cart Is Empty!"))
        {

        }

    }


    public class Cart
    {
        public bool DiscountApplied { get; set; } = false;

        private CartItem _cartItem;
        private Discount _discount=new Discount();
        private string _discountCode;
        public Cart(CartItem cartItem,string discountCode)
        {
            this._cartItem = cartItem;
            this._discountCode = discountCode;
            if (discountCode.Length > 1)
                DiscountApplied = true;
        }

        public double GetTotal()
        {
            double totalPrice = 0;
            foreach (var item in _cartItem.ItemList())
            {
                totalPrice += _cartItem.GetPrice(item.Key);
            }
            return totalPrice;
        }

        public double GetFinalPrice()
        {
            if (DiscountApplied)
            {
                var total = GetTotal();
                return total - (total * _discount.GetDiscount(_discountCode)/100);
            }
            else
            {
                return GetTotal();
            }
        }
    }

    public class Discount {
        private Dictionary<string, double> discountCoupon = new Dictionary<string, double>()
        {
            {"GET50",50 }
        };

        public double GetDiscount(string discountCode)
        {
            if (discountCoupon.ContainsKey(discountCode))
                return discountCoupon[discountCode];
            else
                return 0;
        }
    }

    public enum Category
    {
        dairy=10,
        educational=2,
        entertainment=5,
        grocery=3
    }


}
