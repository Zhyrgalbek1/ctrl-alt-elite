using Task_Meneger.Controllers.Additional_settings.Connection;
using Task_Meneger.Controllers.UserManagers;

namespace Task_Meneger.Views
{
    public class MainMenu
    {
        /// <summary>
        /// Id пользователя.
        /// </summary>
        private int _currentUserId;
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="currentUserId"></param>
        public MainMenu(int currentUserId)
        {
            _currentUserId = currentUserId;
        }
        /// <summary>
        /// Запуск.
        /// </summary>
        public void StartMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\tДобро пожаловать в MyDairy!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1 - Войти\n2 - Регистрация\n0 - Завершение работы.");
                var keyInfo = Console.ReadKey();
                Console.WriteLine();
                switch (keyInfo.KeyChar)
                {
                    case '1': LogInMenu(); break;
                    case '2': SignUpMenu(); break;
                    case '0': return;
                    default: Console.WriteLine("Попробуйте еще раз"); break;
                }
            }

        }
        /// <summary>
        /// Проверка.
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool Verification(UserManager userManager, string login, string password)
        {
            var allUsers = userManager.GetAllUsers();
            var user = allUsers.FirstOrDefault(u => u.Login == login);
            //var aut = new Controllers.Additional_settings.Authorization();
            //var hashPassword = aut.HashPassword(user.Password);
            //aut.VerifyHash(password, hashPassword)
            if (user == null)
            {
                Console.WriteLine("Пользователь не найден!");
            }
            if (login == user.Login && password == user.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Получени данных.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public (string login, string password) Input()
        {
            var authorization = new Controllers.Additional_settings.Authorization();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Логин: ");
            Console.WriteLine("Пароль: ");
            Console.ResetColor();
            Console.SetCursorPosition(10, 0);
            var loginInput = Console.ReadLine();
            if (loginInput == null)
            {
                throw new ArgumentNullException(nameof(loginInput));
            }
            Console.SetCursorPosition(10, 1);
            var passwordInput = authorization.ReadPassword();
            return (loginInput, passwordInput);
        }
        /// <summary>
        /// Меню 'Войти'.
        /// </summary>
        public void LogInMenu()
        {
            var connection = new Connection();
            var userManager = new UserManager(_currentUserId, connection.DefaultCon());
            (string, string) input = Input();

            var verifyPassword = Verification(userManager, input.Item1, input.Item2);

            if (verifyPassword)
            {
                var allUsers = userManager.GetAllUsers();
                var user = allUsers.FirstOrDefault(u => u.Login == input.Item1);
                _currentUserId = user.Id;
                var userMenu = new UserMenu(connection.DefaultCon(), _currentUserId);
                userMenu.Start();
            }
            Console.WriteLine("\nЛогин или пароль не верный!");
            StartMenu();
        }
        /// <summary>
        /// Меню регистрации.
        /// </summary>
        public void SignUpMenu()
        {
            var connection = new Connection();
            var userMenu = new UserMenu(connection.DefaultCon(), _currentUserId);
            userMenu.AddUserMenu();
            Console.ReadKey();
            LogInMenu();
        }

    }
}
