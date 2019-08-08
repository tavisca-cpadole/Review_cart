namespace AddToCart
{
    public class Cart
    {
        public bool DiscountApplied { get; set; } = false;

        private CartItem _cartItem;
        private IDiscount _discount;
        private string _discountCode;
        public Cart(CartItem cartItem, IDiscount discount, string discountCode)
        {
            this._cartItem = cartItem;
            this._discount = discount;
            this._discountCode = discountCode;
            if (discountCode.Length > 1)
                DiscountApplied = true;
        }

        public double GetTotal()
        {
            double totalPrice = 0;
            if (!DiscountApplied)
            {
                foreach (var item in _cartItem.ItemList())
                {
                    totalPrice += _cartItem.GetPrice(item.Key,_discount.GetDiscount(item.Key.Category));
                }
            }
            else
            {
                foreach (var item in _cartItem.ItemList())
                {
                    totalPrice += _cartItem.GetPrice(item.Key);
                }
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


}
