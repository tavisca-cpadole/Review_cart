namespace AddToCart
{
    public class Product {

        public Product(string name,double price,string category) {
            this.Name = name;
            this.Price = price;
            this.Category = category;
        }

        public string Name { get; }
        public double Price { get; }

        public string Category { get; }
    }


}
