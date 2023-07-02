using Task_Meneger.Controllers.DataBase;
using Task_Meneger.Helpers;
using Task_Meneger.Interface;
using Task_Meneger.Models;

namespace Task_Meneger.Controllers.Additional_settings;

public class ForAdmin : IUserManager, ITaskMeneger
{
    /// <summary>
    /// Строка подключения.
    /// </summary>
    private readonly string _connectionString;
    public ForAdmin(string connectionString)
    {
        _connectionString = connectionString;
    }
    /// <summary>
    /// Метод для создания польз.
    /// </summary>
    /// <returns></returns>
    private User ToCreateUserAdmin()
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
    /// <summary>
    /// Метод для создания задачи.
    /// </summary>
    /// <returns></returns>
    private MyTask ToCreateTaskAdmin()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(12, 0);
        var nameTask = Helper.ReadString("Название: ");
        Console.SetCursorPosition(12, 1);
        var description = Helper.ReadString("Описание: ");
        Console.SetCursorPosition(12, 2);
        var StartTask = DateTime.Parse(Helper.ReadString("Начало: "));
        Console.SetCursorPosition(12, 3);
        var Deadline = DateTime.Parse(Helper.ReadString("Конец: "));
        Console.SetCursorPosition(12, 4);
        var Priority_Id = Helper.ReadInt("Приоритет: ");
        Console.SetCursorPosition(12, 5);
        var Status = Helper.ReadInt("Статус: ");
        Console.ResetColor();

        var newtask = new MyTask()
        {
            NameTask = nameTask,
            Description = description,
            StartTask = StartTask,
            Deadline = Deadline,
            Priority = Priority_Id,
            Status = Status
        };
        return newtask;
    }
    /// <summary>
    /// Метод для удаления польз.
    /// </summary>
    public void RemoveUserAdmin()
    {
        try
        {
            GetAllUsersAdmin();
            var databaseUser = new DataBaseMethodsForUsers(_connectionString);
            var id = Helper.ReadInt("Введите Id Ползователя, который хотите удалить: ");
            Console.Clear();
            databaseUser.RemoveUser(id);
            Console.WriteLine("Операция прошла успешно");
        }
        catch
        {
            Console.WriteLine("Ошибка! Введите Еще Раз");
        }
    }
    /// <summary>
    /// Метод для добавления польз.
    /// </summary>
    public void AddUserAdmin()
    {
        var databaseUser = new DataBaseMethodsForUsers(_connectionString);
        databaseUser.AddUser(ToCreateUserAdmin());
        Console.WriteLine("Операция прошла успешно");
    }
    /// <summary>
    /// Метод для редактирования польз.
    /// </summary>
    public void EditUserAdmin()
    {
        try
        {
            GetAllUsersAdmin();
            var databaseUser = new DataBaseMethodsForUsers(_connectionString);
            var id = Helper.ReadInt("Введите id пользователя который хотите изменить: ");
            databaseUser.EditUser(ToCreateUserAdmin(), id);
            Console.WriteLine("Операция прошла успешно");
        }

        catch
        {
            Console.WriteLine("Ошибка! Введите Еще Раз");
        }
    }
    /// <summary>
    /// Метод для получения польз.
    /// </summary>
    public void GetAllUsersAdmin()
    {
        var databaseUser = new DataBaseMethodsForUsers(_connectionString);
        var result = databaseUser.GetAllUsers();
        foreach (var user in result)
        {
            Console.WriteLine($"Id пользователя: {user.Id}");
            Console.WriteLine($"Имя: {user.FirstName}");
            Console.WriteLine($"Фамилия: {user.LastName}");
            Console.WriteLine($"Ник: {user.Login}");
            Console.WriteLine($"Пароль: {user.Password}");
            Console.WriteLine($"Почта email: {user.Email}");
            Console.WriteLine($"Номер телефона: {user.Phone}");
            Console.WriteLine();
        }
    }
    /// <summary>
    /// Метод для получения задач.
    /// </summary>
    public void GetAllTasksAdmin()
    {
        {
            var datebaseTask = new DataBaseMethodsForTask(_connectionString);
            var result = datebaseTask.GetAllTasks();
            foreach (var task in result)
            {
                Console.WriteLine($"Название: {task.NameTask}");
                Console.WriteLine($"Описание: {task.Description}");
                Console.WriteLine($"Начала задачи: {task.StartTask}");
                Console.WriteLine($"Срок окончания: {task.Deadline}");
                Console.WriteLine($"Приоритет: {task.Priority}");
                Console.WriteLine($"Статус: {task.Status}");
                Console.WriteLine();
            }
        }
    }
}




