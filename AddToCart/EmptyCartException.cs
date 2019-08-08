using System;

namespace AddToCart
{
    [Serializable]
    class EmptyCartException : Exception
    {

        public EmptyCartException()
            : base(String.Format("Cart Is Empty!"))
        {

        }

    }


}
