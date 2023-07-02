namespace Task_Meneger.Helpers
{
    public class Helper
    {
        /// <summary>
        /// Метод для прочтения строки
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ReadString(string text)
        {
            Console.Write(text);
            var input = Console.ReadLine();
            if (input != null) return input;
            else throw new ArgumentNullException("Пустая сторка", nameof(input));

        }
        /// <summary>
        /// Метод для прочтения числа
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int ReadInt(string text)
        {
            Console.Write(text);
            return int.Parse(Console.ReadLine());
        }
    }
}
