using System;

namespace AddToCart
{
    [Serializable]
    class NoSuchProductException : Exception
    {

        public NoSuchProductException()
            : base(String.Format("No Such Product Is Present In The Cart!"))
        {

        }

    }


}
