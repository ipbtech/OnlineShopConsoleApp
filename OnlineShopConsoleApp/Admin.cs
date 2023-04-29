namespace OnlineShopConsoleApp
{
    public class Admin
    {
        public Admin()
        {
            Console.WriteLine("Здраствуйте. Вы вошли в панель администратора.");
        }
        public void AdminInfo()
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("Выберите действие, которое хотите совершить:");
            Console.WriteLine("1. Посмотреть список продуктов");
            Console.WriteLine("2. Добавить продукт");
            Console.WriteLine("3. Вернуться назад"); ;
            Console.WriteLine("==========================================================");
        }

        public int AdminAction()
        {
            int numberAction = 0;
            try
            {
                int numberUser = Convert.ToInt32(Console.ReadLine());
                if (numberUser > 0 & numberUser < 4)
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
    }
}

