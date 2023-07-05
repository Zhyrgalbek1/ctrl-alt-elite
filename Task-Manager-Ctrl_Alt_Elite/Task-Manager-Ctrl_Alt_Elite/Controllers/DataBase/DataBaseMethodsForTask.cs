using Microsoft.Data.SqlClient;
using Dapper;
using Task_Meneger.Models;

namespace Task_Meneger.Controllers.DataBase
{
    /// <summary>
    /// Класс для работы с базой данных для задач.
    /// </summary>
    public class DataBaseMethodsForTask
    {
        /// <summary>
        /// Строка подключения.
        /// </summary>
        private readonly string _connection;
        public DataBaseMethodsForTask(string connectionString)
        {
            _connection = connectionString;
        }
        /// <summary>
        /// Метод для получения всех задач.
        /// </summary>
        /// <returns> List<Users>. </returns>
        public List<MyTask> GetAllTasks()
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "SELECT * FROM MyTasks";
                var tasks = connection.Query<MyTask>(sqlcode).ToList();
                return tasks;
            }
        }
        public List<MyTask> GetAllUserTasks(int userId)
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "SELECT * FROM MyTasks WHERE UserId = @UserId";
                var tasks = connection.Query<MyTask>(sqlcode, new { userId }).ToList();
                return tasks;
            }
        }

        /// <summary>
        /// Метод удаление пользователя.
        /// </summary>
        /// <param name="id"></param>
        public void RemoveTask(int id, int userId)
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "DELETE FROM MyTasks WHERE Id = @Id AND UserId = @UserId";
                connection.Execute(sqlcode, new { id, userId });
            }
        }

        /// <summary>
        /// Изменение задачи
        /// </summary>
        /// <param Задача="task"></param>
        /// <param Id задачи="id"></param>
        /// <param Id пользователя="userId"></param>
        public void EditTask(MyTask task, int id, int userId)
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "UPDATE MyTasks SET NameTask = @NameTask, [Description] = @Description, StartTask = @StartTask, Deadline = @Deadline, UserId = @UserId, [Priority_Id] = @Priority_Id, [Status_Id] = @Status WHERE Id = @Id AND UserId = @UserId";
                connection.Execute(sqlcode, new { task.NameTask, task.Description, task.StartTask, task.Deadline, userId, task.Priority, task.Status, id });
            }
        }

        /// <summary>
        /// Добавить задачу
        /// </summary>
        /// <param Задача="task"></param>
        /// <param Id пользователя="userId"></param>
        public void AddTask(MyTask task, int userId)
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "INSERT INTO MyTasks (NameTask, [Description], StartTask, Deadline, UserId, [Priority], [Status]) VALUES (@NameTask, @Description, @StartTask, @Deadline, @userId, @Priority, @Status)";
                connection.Execute(sqlcode, new { task.NameTask, task.Description, task.StartTask, task.Deadline, userId, task.Priority, task.Status });
            }
        }

    }

}
