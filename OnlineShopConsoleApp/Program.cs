namespace OnlineShopConsoleApp
{
    public class Program
    {
        static void Main()
        {
            Store onlineStore = new Store();
            Console.WriteLine("Добро пожаловать в наш онлайн-магазин");
            bool isRight = true;
            do
            {
                StartMenu();
                int numberAction = StartMenuAction();
                # region Показать каталог продуктов
                if (numberAction == 1)
                {
                    onlineStore.ShowCatalog();
                }
                #endregion

                #region Вход в панель администратора
                else if (numberAction == 2)
                {
                    bool adminAccess = AdminAuthorisation();
                    if (adminAccess == true)
                    {
                        Admin admin = new Admin();
                        int adminAction = 0;
                        while (adminAction != 3)
                        {
                            admin.AdminInfo();
                            adminAction = admin.AdminAction();
                            if (adminAction == 1)
                            {
                                onlineStore.ShowCatalog();
                            }
                            else if (adminAction == 2)
                            {
                                #region Получение данных о продукте с консоли
                                Console.WriteLine("Введите название продукта:");
                                string nameProduct = Console.ReadLine();

                                decimal cost;
                                while (true)
                                {
                                    Console.WriteLine("Введите стоимость продукта:");
                                    try
                                    {
                                        cost = Convert.ToDecimal(Console.ReadLine());
                                        break;
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Вы ввели некорректное значение. Введите соответствующую цифру для запуска действия:");
                                    }
                                }
                                #endregion
                                onlineStore.AddProductToStore(nameProduct, cost);
                            }
                        }
                    }
                }
                #endregion
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
                if (userAnswer.ToLower() == "yes") { return userAnswer; }
                else if (userAnswer.ToLower() == "no") { return userAnswer; }
                else { return "None";  }
            }

            static bool AdminAuthorisation()
            {
                bool value = false;
                string login = String.Empty;
                string password = String.Empty;
                while (login != "admin" | password != "admin")
                {
                    Console.WriteLine("Введите логин:");
                    login = Console.ReadLine();
                    Console.WriteLine("Введите пароль:");
                    password = Console.ReadLine();

                    if (login == "admin" & password == "admin")
                    {
                        value = true;
                        break;
                    }
                    else
                    {
                        string userAnswer = "None";
                        Console.WriteLine("Введенные логин и/или пароль не совпадают. Попробовать еще раз? (Yes/No)");
                        while (userAnswer != "yes")
                        {
                            userAnswer = IsYes();
                            if (userAnswer == "no")
                            {
                                value = false;
                                break;
                            }
                            else if (userAnswer != "no" & userAnswer != "yes")
                            {
                                Console.WriteLine("Введите Yes/No");
                            }
                        }
                        if (userAnswer == "no")
                        {
                            value = false;
                            break;
                        }
                    }
                }
                return value;
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
}

