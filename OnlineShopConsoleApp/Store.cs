namespace OnlineShopConsoleApp
{
    public class Store
    {
        public List<Product> Products;
        public List<Product> Basket;
        public List<Order> Orders;
        public Store()
        {
            Products = new List<Product>
            {
                new Product("Хлеб", 25),
                new Product("Молоко", 100),
                new Product("Печенье", 50),
                new Product("Масло", 250),
                new Product("Йогурт", 300),
                new Product("Сок", 80)
            };
        }
        public void AddProductToStore(string name, decimal cost)
        {
            Products.Add(new Product(name, cost));
            Console.WriteLine($"Продукт {name} успешно добавлен в магазин");
        }
        public void ShowCatalog()
        {
            Console.WriteLine("Каталог продуктов:");
            Console.WriteLine("{0, -10} {1, -10} {2, -10}", "Позиция", "Продукт", "Стоимость");
            ShowProducts(Products);
        }
        public void ShowProducts(List<Product> products)
        {
            int number = 1;
            foreach (Product product in products)
            {
                Console.Write("{0, -11}", number + ". ");
                product.Print();
                number++;
            }
        }
    }
}
