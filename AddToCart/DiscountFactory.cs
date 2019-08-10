using System;

namespace AddToCart
{
    public class DiscountFactory
    {
        public IDiscount DiscountType(string type)
        {
            switch (type.ToLowerInvariant())
            {
                case "product":
                    return new CategoryDiscount();
                case "cart":
                    return new CartDiscount();
                default:
                    throw new NotImplementedException();
            }
        }
    }


}
