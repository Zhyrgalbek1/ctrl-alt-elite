using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace Task_Meneger.Controllers.Additional_settings
{
    public class Authorization
    {
        /// <summary>
        /// Метод для создание хэш-ключей.
        /// </summary>
        /// <returns></returns>
        private byte[] CreateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        /// <summary>
        /// Метод для хэширование пароля.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public byte[] HashPassword(string password)
        {
            byte[] salt = CreateSalt();

            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                Iterations = 4,
                MemorySize = 1024 * 1024
            };

            return argon2.GetBytes(16);
        }
        /// <summary>
        /// Метод для проверки хэш-пароля.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public bool VerifyHash(string password, byte[] hash)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
            return argon2.Equals(hash);
        }
        /// <summary>
        /// Метод для чтения пароля.
        /// </summary>
        /// <returns></returns>
        public string ReadPassword()
        {
            string password = "";
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
            }
            return password;
        }
    }
}
