using System;
using System.Collections.Generic;

namespace AddToCart
{
    //public enum Category
    //{
    //    dairy=10,
    //    educational=2,
    //    entertainment=5,
    //    grocery=3
    //}

    public class CategoryDiscount:IDiscount
    {
        private Dictionary<string, double> _category = new Dictionary<string, double>() {
            {"Grocery",10 },
            {"Entertainment",10 },
            {"Stationary",10 }
        };

        public double GetDiscount(string category)
        {
            if (_category.ContainsKey(category))
                return _category[category];
            else
                return 0;
        }

        public void AddDiscount(string category, double discount)
        {
            _category.Add(category,discount);
        }

        public void UpdateDiscount(string category, double updatedDiscount)
        {
            try
            {
                if (_category.ContainsKey(category))
                {
                    _category[category] = updatedDiscount;
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
            catch (Exception e)
            {
                //
            }
        }
    }


}
