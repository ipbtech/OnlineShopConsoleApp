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
            Console.WriteLine($"{Name} {Price}");
        }
    }
    public class Order
    {
        public List<Product> Products;
        public decimal FullPrice;
        public Order(List<Product> products)
        {
            Products = products;

            foreach (var product in products)
            {
                FullPrice += product.Price;
            }
        }
    }
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
            Basket = new List<Product>();
            Orders = new List<Order>();
        }
        public void ShowCatalog()
        {
            Console.WriteLine("Каталог продуктов");
            ShowProducts(Products);
        }
        public void ShowBasket()
        {
            Console.WriteLine("Содержимое корзины");
            ShowProducts(Basket);
        }
        public void AddToBasket(int numberProduct)
        {
            Basket.Add(Products[numberProduct - 1]);
            Console.WriteLine($"Продукт {Products[numberProduct - 1].Name} успешно добавлен в корзину.");
            Console.WriteLine($"В корзине {Basket.Count} продуктов.");
        }
        public void ShowProducts(List<Product> products)
        {
            int number = 1;
            foreach (Product product in products)
            {
                Console.Write(number + ". ");
                product.Print();
                number++;
            }
        }
        public void CreateOrder()
        {
            Order order = new Order(Basket);
            Orders.Add(order);

            Basket.Clear();
        }
    }
    public class Program
    {
        static void Main()
        {
            Store onlineStore = new Store();

            Console.WriteLine("Здравствуйте. Выберите действие:");
            Console.WriteLine("1. Показать каталог продуктов?");
            Console.WriteLine("Выберите номер действия, которое хотите совершить.");
            int numberAction = Convert.ToInt32(Console.ReadLine());

            switch (numberAction)
            {
                case 1: 
                    onlineStore.ShowCatalog(); 
                    break;
                default:
                    Console.WriteLine("Выберите номер действия из списка");
                    break;
            }

            bool yes;
            do
            {
                Console.WriteLine("Хотите добавить продукт в корзину? Введите Да или Нет.");
                yes = IsYes(Console.ReadLine());
                if (yes)
                {
                    //onlineStore.ShowCatalog();
                    Console.WriteLine("Введите номер продукта, который нужно добавить в корзину");
                    int productNumber = Convert.ToInt32(Console.ReadLine());
                    onlineStore.AddToBasket(productNumber);
                }
            } 
            while (yes);

            Console.WriteLine("Хотите посмотреть корзину? Наберите Да или Нет.");
            yes = IsYes(Console.ReadLine());
            if (yes)
            {
                onlineStore.ShowBasket();
            }
            Console.WriteLine("Хотите оформить заказ? Наберите Да или Нет.");
            yes = IsYes(Console.ReadLine());
            if (yes)
            {
                onlineStore.CreateOrder();
            }
        }

        static bool IsYes(string answer)
        {
            return answer.ToLower() == "да";
        }
    }
}
