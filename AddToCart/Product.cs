namespace AddToCart
{
    public class Product {

        public Product(string name,double price,string category) {
            Name = name;
            Price = price;
            Category = category;
        }

        public string Name { get; }
        public double Price { get; }

        public string Category { get; }
    }


}
