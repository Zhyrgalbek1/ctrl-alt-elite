using Task_Meneger.Controllers.DataBase;
using Task_Meneger.Helpers;
using Task_Meneger.Models;

namespace Task_Meneger.Views
{
    public class UserMenu
    {
        private readonly int _currentUserId;
        /// <summary>
        /// Строка подключения.
        /// </summary>
        private readonly string _connectionString;
        /// <summary>
        /// Созадение обьекта класса и передача строки подк.
        /// </summary>
        /// <param name="database"></param>
        public UserMenu(string connection, int userId)
        {
            _currentUserId = userId;
            _connectionString = connection;
        }
        /// <summary>
        /// Класс Start для вывода в консоль
        /// </summary>
        /// <returns></returns>
        public void Start()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в менеджер пользователей!");
            Console.WriteLine("=======================");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Выберите опцию:");
                Console.WriteLine("1 - Редактировать профиль.");
                Console.WriteLine("2 - Удалить профиль.");
                Console.WriteLine("3 - Переключится на менеджер задач.");
                Console.WriteLine("4 - Переключится в режим админа.");
                Console.WriteLine("0 - Выход.");
                Console.WriteLine("=======================");
                Console.WriteLine();


                var keyInfo = Console.ReadKey();
                Console.WriteLine();

                switch (keyInfo.KeyChar)
                {
                    case '1':
                        EditUserMenu(); break;
                    case '2':
                        DeleteUserMenu(); break;
                    case '3':
                        var taskMenu = new TaskMenu(_connectionString, _currentUserId);
                        taskMenu.Start(); break;
                    case '4':
                        var admin = new AdminMenu(_connectionString, _currentUserId);
                        admin.Start(); break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Неверный вариант. Пожалуйста, попробуйте еще раз.");
                        break;
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Метод для добавления пользователя.
        /// </summary>
        public void AddUserMenu()
        {
            Console.WriteLine("Добавить нового пользователя:");
            Console.WriteLine("===============");

            var user = new User();


            user.FirstName = Helper.ReadString("Имя: ");

            user.LastName = Helper.ReadString("Фамилия: ");

            user.Login = Helper.ReadString("Ник: ");

            user.Password = Helper.ReadString("Пароль: ");

            user.Email = Helper.ReadString("Почта email: ");
            ;
            user.Phone = Helper.ReadString("Номер телефона: ");

            var data = new DataBaseMethodsForUsers(_connectionString);
            data.AddUser(user);
            Console.WriteLine("Пользователь успешно добавлен!");
        }
        /// <summary>
        /// Метод для удаления профиля.
        /// </summary>
        /// <returns></returns>
        private void DeleteUserMenu()
        {
            var login = Helper.ReadString("Введите ник пользователя для удаления: ");

            var data = new DataBaseMethodsForUsers(_connectionString);
            var user = data.GetUserByLogin(login);

            if (user != null)
            {
                data.RemoveUser(user.Id);

                Console.WriteLine("Пользователь успешно удален");
            }
            else
            {
                Console.WriteLine("Пользователь не найден");
            }
        }
        /// <summary>
        /// Метод для редактирования профиля.
        /// </summary>
        private void EditUserMenu()
        {
            Console.Write("Введите ник пользователя: ");
            string login = Console.ReadLine();

            var data = new DataBaseMethodsForUsers(_connectionString);
            var user = data.GetUserByLogin(login);

            if (user != null)
            {
                Console.Write("Введите ник: ");
                string newLogin = Console.ReadLine();

                if (!string.IsNullOrEmpty(newLogin))
                {
                    user.Login = newLogin;
                }

                Console.Write("Введите имя: ");
                string newFirstname = Console.ReadLine();

                if (!string.IsNullOrEmpty(newFirstname))
                {
                    user.FirstName = newFirstname;
                }

                Console.Write("Введите фамилию: ");
                string newLastname = Console.ReadLine();

                if (!string.IsNullOrEmpty(newLastname))
                {
                    user.LastName = newLastname;
                }

                Console.Write("Введите пароль: ");
                string newPassword = Console.ReadLine();

                if (!string.IsNullOrEmpty(newPassword))
                {
                    int newDuration = int.Parse(newPassword);
                    user.Password = newPassword;
                }

                Console.Write("Введите почту email: ");
                string newEmail = Console.ReadLine();

                if (!string.IsNullOrEmpty(newEmail))
                {
                    user.Email = newEmail;
                }

                Console.Write("Введите номер телефона: ");
                string newPhone = Console.ReadLine();

                if (!string.IsNullOrEmpty(newPhone))
                {
                    user.Phone = newPhone;
                }

                data.EditUser(user, _currentUserId);

                Console.WriteLine("Пользователь успешно обновлен");
            }
            else
            {
                Console.WriteLine("Пользователь не найден");
            }
        }
    }
}

