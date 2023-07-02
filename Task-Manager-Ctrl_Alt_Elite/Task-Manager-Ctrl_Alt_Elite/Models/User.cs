namespace Task_Meneger.Models
{
    public class User
    {
        /// <summary>
        /// ID пользователя.
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        private string _firstName;
        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        private string _lastName;
        /// <summary>
        /// Логин пользователя.
        /// </summary>
        private string _login;
        public string FirstName
        {
            get => _firstName; set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Имя не может быть пустым", nameof(value));
                }
                _firstName = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Фамилия не может быть пустым", nameof(value));
                }
                _lastName = value;
            }
        }
        public string Login
        {
            get => _login;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Логин не может быть пустым", nameof(value));
                }
                _login = value;
            }
        }
        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// Тел. номер.
        /// </summary>
        public string Phone { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"Имя: {_firstName} | Фамилия: {_lastName}." +
                $"\nLogin: {Login} | Password: {Password}." +
                $"\nEmail: {Email} | Тел. номер: {Phone}.";
        }

    }
}
