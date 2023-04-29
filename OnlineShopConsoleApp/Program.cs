namespace OnlineShopConsoleApp
{
    public class Program
    {
        static void Main()
        {
            Store onlineStore = new Store();
            Console.WriteLine("Добро пожаловать в наш онлайн-магазин");

            {
                StartMenu();
                int numberAction = StartMenuAction();
                // Показать каталог продуктов
                if (numberAction == 1)
                {
                    onlineStore.ShowCatalog();
                }
                // Войти как админ
                else if (numberAction == 2)
                {
                    string login = String.Empty;
                    string password = String.Empty;
                    while (login != "admin" & password != "admin")
                    {
                        Console.WriteLine("Введите логин:");
                        login = Console.ReadLine();
                        Console.WriteLine("Введите пароль:");
                        password = Console.ReadLine();

                        if (login == "admin" & password == "admin")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Введенные логин и/или пароль не совпадают. Попробовать еще раз? (Yes/No)");
                            string userAnswer = IsYes();;
                            if (userAnswer == "no")
                            {
                                break;
                            }
                            else if 
                            {
                                userAnswer = IsYes();
                            }
                            

                        }
                    }
                }


                else if (numberAction == 3)
                {

                }
                else if (numberAction == 4)
                {
                    Console.WriteLine("До новых встреч!");
                    isRight = false;
                }
            }
            while (isRight);

            





                    //switch (numberAction)
                    //{
                    //    case 1: 
                    //        onlineStore.ShowCatalog(); 
                    //        break;
                    //    default:
                    //        Console.WriteLine("Выберите номер действия из списка");
                    //        break;
                    //}

                    //bool yes;
                    //do
                    //{
                    //    Console.WriteLine("Хотите добавить продукт в корзину? Введите Да или Нет.");
                    //    yes = IsYes(Console.ReadLine());
                    //    if (yes)
                    //    {
                    //        //onlineStore.ShowCatalog();
                    //        Console.WriteLine("Введите номер продукта, который нужно добавить в корзину");
                    //        int productNumber = Convert.ToInt32(Console.ReadLine());
                    //        onlineStore.AddToBasket(productNumber);
                    //    }
                    //} 
                    //while (yes);

                    //Console.WriteLine("Хотите посмотреть корзину? Наберите Да или Нет.");
                    //yes = IsYes(Console.ReadLine());
                    //if (yes)
                    //{
                    //    onlineStore.ShowBasket();
                    //}
                    //Console.WriteLine("Хотите оформить заказ? Наберите Да или Нет.");
                    //yes = IsYes(Console.ReadLine());
                    //if (yes)
                    //{
                    //    onlineStore.CreateOrder();
                    //}
            

            static void StartMenu()
            {
                Console.WriteLine("==========================================================");
                Console.WriteLine("Выберите действие, которое хотите совершить:");
                Console.WriteLine("1. Посмотреть список продуктов в магазине");
                Console.WriteLine("2. Войти как администратор для добавления новых продуктов");
                Console.WriteLine("3. Войти как покупатель");
                Console.WriteLine("4. Завершить работу");
                Console.WriteLine("==========================================================");
            }

            static int StartMenuAction()
            {
                int numberAction = 0;
                try
                {
                    int numberUser = Convert.ToInt32(Console.ReadLine());
                    if (numberUser > 0 & numberUser < 5)
                    {
                        numberAction = numberUser;
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
                return numberAction;
            }

            static string IsYes()
            {
                string userAnswer = Console.ReadLine();
                if (userAnswer.ToLower() == "yes") 
                { 
                    return userAnswer; 
                }
                else if (userAnswer.ToLower() == "no") 
                { 
                    return userAnswer; 
                }
                else 
                { 
                    return "None"; 
                }
            }

            static void AdminMenu()
            {
                Console.WriteLine("==========================================================");
                Console.WriteLine("Выберите действие, которое хотите совершить:");
                Console.WriteLine("1. Посмотреть список продуктов");
                Console.WriteLine("2. Добавить продукт");
                Console.WriteLine("3. Вернуться назад"); ;
                Console.WriteLine("==========================================================");
            }
            static void SecondMenu()
            {
                Console.WriteLine("==========================================================");
                Console.WriteLine("Выберите действие, которое хотите совершить:");
                Console.WriteLine("1. Пойти за покупками");
                Console.WriteLine("2. Посмотреть мои заказы");
                Console.WriteLine("3. Завершить работу");
                Console.WriteLine("==========================================================");
            }
            static void ThirdMenu()
            {
                Console.WriteLine("==========================================================");
                Console.WriteLine("Выберите действие, которое хотите совершить:");
                Console.WriteLine("1. Добавить товар в корзину");
                Console.WriteLine("2. Посмотреть корзину");
                Console.WriteLine("3. Завершить работу");
                Console.WriteLine("==========================================================");
            }
            static bool IncorrectAction()
            {
                bool act;
                try
                {
                    int numberAction = Convert.ToInt32(Console.ReadLine());
                    act = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Вы ввели некорректное значение. Введите соответствующую цифру для запуска действия");
                    act = false;
                }
                return act;
            }
        }
    }
    public class Admin
    {
        public string Login = "admin";
        public string Password = "admin";
        public Admin(string login, string password)
        {
            if (login == Login & password == Password)
            {

            }
            else
            {
                while (login != Login & password != Password)
                {

                }
            }
        }

    }
}

