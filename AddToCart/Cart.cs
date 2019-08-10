namespace AddToCart
{
    public class Cart
    {
        private bool _DiscountApplied { get; set; } = false;

        private CartItem _cartItem;
        private IDiscount _discount;
        private string _isdiscountCode;
        public Cart(CartItem cartItem, IDiscount discount, string discountCode)
        {
            _cartItem = cartItem;
            _discount = discount;
            _isdiscountCode = discountCode;
            if (discountCode.Length > 1)
                _DiscountApplied = true;
        }

        public double GetTotal()
        {
            double totalPrice = 0;
            if (!_DiscountApplied)
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
            if (_DiscountApplied)
            {
                var total = GetTotal();
                return total - (total * _discount.GetDiscount(_isdiscountCode)/100);
            }
            else
            {
                return GetTotal();
            }
        }
    }


}
