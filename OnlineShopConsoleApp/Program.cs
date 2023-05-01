using System.Reflection.Metadata;

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
                int numberAction = MenuAction();
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
                                        if (cost > 0) { break; }
                                        else { Console.WriteLine("Вы ввели некорректное значение. Введите соответствующую цифру для запуска действия:"); }
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

                #region Вход в магазин как покупатель
                else if (numberAction == 3)
                {
                    User user = new User();
                    int userStartAction = 0;
                    while (userStartAction != 4)
                    {
                        user.UserInfo();
                        userStartAction = MenuAction();

                        #region Пойти за покупками
                        if (userStartAction == 1)
                        {
                            onlineStore.ShowCatalog();
                            user.GoToTheStore(onlineStore);

                            // Действия из корзины
                            int userBasketAction = 0;
                            while (userBasketAction != 3)
                            {
                                userBasketAction = user.BasketAction();

                                #region Просмотр корзины и оформлнение заказа по запросу пользователя
                                if (userBasketAction == 1)
                                {
                                    user.ShowBasket();
                                    if (!user.IsBasketEmpty())
                                    {
                                        ActionFromBasket(user);
                                        break;
                                    }
                                }
                                #endregion

                                #region Оформление заказа
                                else if (userBasketAction == 2)
                                {
                                    user.CreateOrder();
                                    break;
                                }
                                #endregion
                            }
                        }
                        #endregion

                        #region Просмотр корзины и оформлнение заказа по запросу пользователя
                        else if (userStartAction == 2)
                        {
                            user.ShowBasket();
                            if (!user.IsBasketEmpty())
                            {
                                ActionFromBasket(user);
                            }
                        }
                        #endregion
                        // work in progress
                        #region Просмотр всех заказов
                        else if (userStartAction == 3)
                        {
                            user.ShowAllOrders();
                        }
                        #endregion
                    }
                }
                #endregion

                #region Завершение работы консольного приложения
                else if (numberAction == 4)
                {
                    Console.WriteLine("До новых встреч!");
                    isRight = false;
                }
                #endregion
            }
            while (isRight);
        }
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
        public static string IsYes()
        {
            string userAnswer = Console.ReadLine();
            if (userAnswer.ToLower() == "yes") { return userAnswer; }
            else if (userAnswer.ToLower() == "no") { return userAnswer; }
            else { return "None"; }
        }
        public static int MenuAction()
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
        public static void ActionFromBasket(User user)
        {
            Console.WriteLine("Оформить заказ? (Yes/No)");
            string userAnswer = "None";
            while (userAnswer != "yes")
            {
                userAnswer = IsYes();
                if (userAnswer == "no")
                {
                    break;
                }
                else if (userAnswer != "no" & userAnswer != "yes")
                {
                    Console.WriteLine("Введите Yes/No");
                }
            }
            if (userAnswer == "yes")
            {
                user.CreateOrder();
            }
        }
    }
}

