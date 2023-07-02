using Task_Meneger.Controllers.Additional_settings;
using Task_Meneger.Controllers.DataBase;
using Task_Meneger.Helpers;

namespace Task_Meneger.Views
{
    public class AdminMenu
    {
        /// <summary>
        /// Строка подключения.
        /// </summary>
        private readonly string _connectionString;
        /// <summary>
        /// ID пользователя.
        /// </summary>
        private readonly int _currentUserId;

        /// <summary>
        /// Созадение обьекта класса и передача строки подк.
        /// </summary>
        /// <param name="database"></param>
        public AdminMenu(string connection, int userId)
        {
            _currentUserId = userId;
            _connectionString = connection;
        }
        /// <summary>
        /// Метод запуск.
        /// </summary>
        public void Start()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в режим админ!");
            Console.WriteLine("=======================");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Выберите опцию:");
                Console.WriteLine("1 - Получить список пользователей.");
                Console.WriteLine("2 - Изменить данные пользователя.");
                Console.WriteLine("3 - Удалить пользователя.");
                Console.WriteLine("4 - Получить все задачи.");
                Console.WriteLine("5 - Поиск пользователя по нику.");
                Console.WriteLine("0 - Выход.");
                Console.WriteLine("=======================");
                Console.WriteLine();


                var keyInfo = Console.ReadKey();
                Console.WriteLine();

                switch (keyInfo.KeyChar)
                {
                    case '1': GetAllUsers(); break;
                    case '2': ChangedateUsers(); break;
                    case '3': RemoveUsers(); break;
                    case '4': GetAllTask(); break;
                    case '5': GetUserByLoginMenu(); break;
                    case '0': return;
                    default:
                        Console.WriteLine("Неверный вариант. Пожалуйста, попробуйте еще раз.");
                        break;
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Метод для получения всех пользователей.
        /// </summary>
        private void GetAllUsers()
        {
            var admin = new ForAdmin(_connectionString);
            admin.GetAllUsersAdmin();
        }
        /// <summary>
        /// Метод для редактирования данных пользователя.
        /// </summary>
        private void ChangedateUsers()
        {
            var admin = new ForAdmin(_connectionString);
            admin.EditUserAdmin();
        }
        /// <summary>
        /// Мнтод для удаления пользователя.
        /// </summary>
        private void RemoveUsers()
        {
            var admin = new ForAdmin(_connectionString);
            admin.RemoveUserAdmin();
        }
        /// <summary>
        /// Метод для полученния всех задач.
        /// </summary>
        private void GetAllTask()
        {
            var admin = new ForAdmin(_connectionString);
            admin.GetAllTasksAdmin();
        }
        /// <summary>
        /// Метод для поиска по нику.
        /// </summary>
        /// <returns></returns>
        private void GetUserByLoginMenu()
        {
            var name = Helper.ReadString("Введите ник пользователя: ");

            var data = new DataBaseMethodsForUsers(_connectionString);
            var user = data.GetUserByLogin(name);

            if (user == null)
            {
                Console.WriteLine("Пользователь не найден.");
            }
            else
            {
                Console.WriteLine($"Id пользователя: {user.Id}");
                Console.WriteLine($"Имя: {user.FirstName}");
                Console.WriteLine($"Фамилия: {user.LastName}");
                Console.WriteLine($"Ник: {user.Login}");
                Console.WriteLine($"Пароль: {user.Password}");
                Console.WriteLine($"Почта email: {user.Email}");
                Console.WriteLine($"Номер телефона: {user.Phone}");
            }
        }
    }
}
