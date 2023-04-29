namespace OnlineShopConsoleApp
{
    public class Product
    {
        public string Name;
        public decimal Price;
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public void Print()
        {
            Console.WriteLine("{0, -10} {1, -10}", Name, Price);
        }
    }
}
