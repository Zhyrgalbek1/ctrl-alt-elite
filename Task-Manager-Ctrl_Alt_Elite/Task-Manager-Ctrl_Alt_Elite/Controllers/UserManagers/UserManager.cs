using Task_Meneger.Controllers.DataBase;
using Task_Meneger.Helpers;
using Task_Meneger.Interface;
using Task_Meneger.Models;

namespace Task_Meneger.Controllers.UserManagers
{
    public class UserManager : IUserManager
    {
        /// <summary>
        /// Id пользователя.
        /// </summary>
        private readonly int _currentIdUser;
        /// <summary>
        /// Строка подключения.
        /// </summary>
        private readonly string _connectionString;
        public UserManager(int curentIdUser, string connectionString)
        {
            _currentIdUser = curentIdUser;
            _connectionString = connectionString;
        }
        /// <summary>
        /// Метод для удаления польз.
        /// </summary>
        public void RemoveUser()
        {
            var databaseUser = new DataBaseMethodsForUsers(_connectionString);
            databaseUser.RemoveUser(_currentIdUser);
            Console.WriteLine("Операция прошла успешно");
        }
        /// <summary>
        /// Метод для получения польз.
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            var databaseUser = new DataBaseMethodsForUsers(_connectionString);
            var result = databaseUser.GetAllUsers();
            return result;
        }
        /// <summary>
        /// Метод для добавления польз.
        /// </summary>
        public void AddUser()
        {
            var databaseUser = new DataBaseMethodsForUsers(_connectionString);
            databaseUser.AddUser(ToCreateUser());
            Console.WriteLine("Операция прошла успешно");
        }
        /// <summary>
        /// Метод для редактирования.
        /// </summary>
        public void EditUser()
        {
            var databaseUser = new DataBaseMethodsForUsers(_connectionString);
            databaseUser.EditUser(ToCreateUser(), _currentIdUser);
            Console.WriteLine("Операция прошла успешно");
        }
        /// <summary>
        /// Метод для получения польз. по логину.
        /// </summary>
        /// <returns></returns>
        public User GetUserByLogin()
        {
            var databaseUser = new DataBaseMethodsForUsers(_connectionString);
            var login = Helper.ReadString("Введите login: ");
            Console.WriteLine("Операция прошла успешно");
            return databaseUser.GetUserByLogin(login);
        }
        /// <summary>
        /// Метод для создания польз.
        /// </summary>
        /// <returns></returns>
        private User ToCreateUser()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(12, 0);
            var firstName = Helper.ReadString("Введите Имя: ");
            Console.SetCursorPosition(12, 1);
            var lastName = Helper.ReadString("Введите Фамилию: ");
            Console.SetCursorPosition(12, 2);
            var login = Helper.ReadString("Введите Логин: ");
            Console.SetCursorPosition(12, 3);
            var password = Helper.ReadString("Введите Пароль: ");
            Console.SetCursorPosition(12, 4);
            var email = Helper.ReadString("Введите Email: ");
            Console.SetCursorPosition(12, 5);
            var phone = Helper.ReadString("Введите Номер Телефона: ");
            Console.ResetColor();
            var newuser = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Login = login,
                Password = password,
                Email = email,
                Phone = phone
            };
            return newuser;
        }
    }
}
