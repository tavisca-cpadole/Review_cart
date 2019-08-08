using System;
using System.Collections.Generic;

namespace AddToCart
{
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

        public double GetPrice(Product product,double discount=0)
        {
            try
            {
                return _cartItems[product] * product.Price - _cartItems[product] * product.Price*discount/100;
            }
            catch (Exception)
            {
                throw new EmptyCartException();
            }
        }


    }


}
