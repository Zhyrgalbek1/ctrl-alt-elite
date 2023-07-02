namespace Task_Meneger.Models
{
    public class MyTask
    {
        /// <summary>
        /// ID задачи.
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        private string _name;
        public string NameTask
        {
            get => _name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Пустое название задачи.", nameof(value));
                }
                _name = value;
            }
        }
        /// <summary>
        /// Описание задачи.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Время началы задачи.
        /// </summary>
        public DateTime StartTask { get; set; }
        /// <summary>
        /// Статус задачи.
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Приоритет задачи.
        /// </summary>

        public int Priority { get; set; }
        /// <summary>
        /// Дедлайн задачи.
        /// </summary>
        public DateTime Deadline { get; set; }

        public override string ToString() => $"Id задачи: {Id} | Название задачи: {_name}" +
                                          $"\nОписание: {Description}." +
                                          $"\nНачало: {StartTask} | Dealine: {Deadline}." +
                                          $"\nСтатус: {Status} | Приоритет: {Priority}.";

    }
}
