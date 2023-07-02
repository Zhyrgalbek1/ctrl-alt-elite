using Task_Meneger.Controllers.DataBase;
using Task_Meneger.Helpers;
using Task_Meneger.Models;

namespace Task_Meneger.Views
{
    public class TaskMenu
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
        public TaskMenu(string connection, int userId)
        {
            _currentUserId = userId;
            _connectionString = connection;
        }
        /// <summary>
        /// Метод для запуска меню.
        /// </summary>
        /// <returns></returns>
        public void Start()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в менеджер задач!");
            Console.WriteLine("=======================");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Выберите опцию:");
                Console.WriteLine("1 - Посмотреть все задачи");
                Console.WriteLine("2 - Добавить новую задачу");
                Console.WriteLine("3 - Удалить задачу");
                Console.WriteLine("0. Выход");
                Console.WriteLine("=======================");
                Console.WriteLine();


                var keyInfo = Console.ReadKey();
                Console.WriteLine();

                switch (keyInfo.KeyChar)
                {
                    case '1': GetAllUserTasks(); break;
                    case '2': AddTask(); break;
                    case '3': RemoveUserTask(); break;
                    case '0': return;
                    default:
                        Console.WriteLine("Неверный вариант. Пожалуйста, попробуйте еще раз.");
                        break;
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Метод для добавление задачи.
        /// </summary>
        private void AddTask()
        {
            Console.WriteLine("Добавить новую задачу:");
            Console.WriteLine("===============");

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

            var data = new DataBaseMethodsForTask(_connectionString);
            data.AddTask(newtask, _currentUserId);
            Console.WriteLine("Задача успешно добавлена!");
        }

        /// <summary>
        /// Метод для получение задач.
        /// </summary>
        /// <returns></returns>
        private void GetAllUserTasks()
        {
            var data = new DataBaseMethodsForTask(_connectionString);
            var tasks = data.GetAllUserTasks(_currentUserId);
            foreach (var task in tasks)
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
        /// <summary>
        /// Метод для удаления задачи.
        /// </summary>
        /// <returns></returns>
        private void RemoveUserTask()
        {
            GetAllUserTasks();
            var id = Helper.ReadInt("Введите ID задачи для удаления: ");

            var data = new DataBaseMethodsForTask(_connectionString);
            data.RemoveTask(id, _currentUserId);
            Console.WriteLine("Задача удалена!");
        }

    }
}

