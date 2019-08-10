using System.Collections.Generic;

namespace AddToCart
{
    public class CartDiscount :IDiscount
    {
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


}
