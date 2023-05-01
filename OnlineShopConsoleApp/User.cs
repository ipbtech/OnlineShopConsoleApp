namespace OnlineShopConsoleApp
{
    public class User
    {
        List<Product> Basket;
        List<Order> Orders;
        public User()
        {
            Console.WriteLine("Вы вошли как покупатель.");
            Basket = new List<Product>();
            Orders = new List<Order>();
        }
        public void UserInfo()
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("Выберите действие, которое хотите совершить:");
            Console.WriteLine("1. Пойти за покупками");
            Console.WriteLine("2. Открыть корзину");
            Console.WriteLine("3. Посмотреть мои заказы");
            Console.WriteLine("4. Вернуться назад");
            Console.WriteLine("==========================================================");
        }
        public bool IsBasketEmpty()
        {
            if (Basket.Count() == 0) { return true; }
            else { return false; }
        }
        public void ShowBasket()
        {
            if (Basket.Count() != 0)
            {
                Console.WriteLine("Содержимое корзины:");
                Console.WriteLine("{0, -10} {1, -10} {2, -10}", "Позиция", "Продукт", "Стоимость");
                ShowProducts(Basket);
                Console.WriteLine("{0, -10} {1, -10} {2, -10}", "Итого:", "", SumCostOfProductsInTheBasket());
            }
            else
            {
                Console.WriteLine("Упс! В корзине пока ничего нет");
            }
        }
        public int BasketAction()
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("Выберите действие, которое хотите совершить:");
            Console.WriteLine("1. Посмотреть корзину");
            Console.WriteLine("2. Оформить заказ");
            Console.WriteLine("3. Вернуться назад");
            Console.WriteLine("==========================================================");

            int numberAction = 0;
            while (true)
            {
                try
                {
                    int numberUser = Convert.ToInt32(Console.ReadLine());
                    if (numberUser > 0 & numberUser < 4)
                    {
                        numberAction = numberUser;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели некорректное значение. Введите соответствующую цифру для запуска действия:");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Вы ввели некорректное значение. Введите соответствующую цифру для запуска действия:");
                }
            }
            return numberAction;
        }

        private decimal SumCostOfProductsInTheBasket()
        {
            decimal sumCost = 0;
            foreach (Product product in Basket) { sumCost += product.Price; }
            return sumCost;
        }
        public void AddToBasket(Store store, int numberProduct)
        {
            Basket.Add(store.Products[numberProduct - 1]);
            Console.WriteLine($"Продукт {store.Products[numberProduct - 1].Name} успешно добавлен в корзину.");
            //Console.WriteLine($"В корзине {Basket.Count} продуктов.");
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
        public void CreateOrder()
        {
            Order order = new Order(Basket);
            Orders.Add(order);
            Basket.Clear();

            Console.WriteLine($"Заказ стоимостью {order.FullPrice} успешно оформлен и передан в отдел доставки");
        }
        public void GoToTheStore(Store store)
        {
            while (true)
            {
                Console.WriteLine("Для добавления продукта в корзину введите его порядковый номер. \n" +
                "Для выхода введите \"exit\"");

                string userAnswerAboutAdding = Console.ReadLine();
                if (userAnswerAboutAdding.ToLower() != "exit")
                {
                    try
                    {
                        int numProduct = Convert.ToInt32(userAnswerAboutAdding);
                        if (numProduct > 0 & numProduct < store.Products.Count()+1) 
                        {
                            AddToBasket(store, numProduct);

                            Console.WriteLine("Добавить еще продукт? (Yes/No)");
                            string userAnswer = "None";
                            while (userAnswer != "yes")
                            {
                                userAnswer = Program.IsYes();
                                if (userAnswer == "no")
                                {
                                    break;
                                }
                                else if (userAnswer != "no" & userAnswer != "yes")
                                {
                                    Console.WriteLine("Введите Yes/No");
                                }
                            }
                            if (userAnswer == "no") { break; }
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели некорректное значение.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Вы ввели некорректное значение.");
                    }
                }
                else { break; } 
            }
        }

        public void ShowAllOrders()
        {
            if (Orders.Count() == 0)
            {
                Console.WriteLine("Упс! Кажется вы еще не сделали ни одного заказа");
            }
            else
            {
                int i = 1;
                foreach (Order order in Orders)
                {
                    Console.WriteLine($"Заказ №{i} общей стоимостью {order.FullPrice} готов к выдаче.");
                    i++;
                }
            }
        }
    }
}

