using Task_Meneger.Controllers.Additional_settings;
using Task_Meneger.Controllers.DataBase;
using Task_Meneger.Controllers.TaskManager;
using Task_Meneger.Helpers;

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
                Console.WriteLine("4 - Экспортировать задачи.");
                Console.WriteLine("5 - Импортировать задачи.");
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
                    case '4': ExportTask(); break;
                    case '5': ImportTask(); break;
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
            Console.Clear();
            var taskManager = new TaskManager(_currentUserId, _connectionString);
            taskManager.AddNewTask();

            Console.WriteLine("Задача успешно добавлена!");
        }

        /// <summary>
        /// Метод для получение задач.
        /// </summary>
        /// <returns></returns>
        private void GetAllUserTasks()
        {
            Console.Clear();
            var data = new DataBaseMethodsForTask(_connectionString);
            var tasks = data.GetAllUserTasks(_currentUserId);
            foreach (var task in tasks)
            {
                Console.WriteLine($"Id: {task.Id}");
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
            Console.Clear();
            GetAllUserTasks();
            var id = Helper.ReadInt("Введите ID задачи для удаления: ");

            var data = new DataBaseMethodsForTask(_connectionString);
            data.RemoveTask(id, _currentUserId);
            Console.WriteLine("Задача удалена!");
        }
        /// <summary>
        /// Импортировать задачу.
        /// </summary>
        private void ImportTask()
        {
            Console.Clear();
            var jsonImport = new JsonConnection();
            var importTask = jsonImport.ImportJson(Helper.ReadString("Введите название файла: "));
            foreach (var task in importTask)
            {
                Console.WriteLine($"ID: {task.Id}.\nНазвание: {task.NameTask}.\nОписание: {task.Description}" +
                            $"\nНачало: {task.StartTask}.\nDeadline: {task.Deadline}.\nПриоритет: {task.Priority}.\nСтатус: {task.Status}.");
            }
        }
        /// <summary>
        /// Экспортировать задачу.
        /// </summary>
        private void ExportTask()
        {
            Console.Clear();
            var jsonImport = new JsonConnection();
            var data = new DataBaseMethodsForTask(_connectionString);
            var tasks = data.GetAllUserTasks(_currentUserId);
            jsonImport.ExporJson(tasks);
        }
    }
}

