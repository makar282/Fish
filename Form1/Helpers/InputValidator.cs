using System.Text.RegularExpressions;

namespace Form1.Helpers
{
    /// <summary>
    /// Класс для проверки ввода данных
    /// </summary>
    public class InputValidator
    {
        /// <summary>
        /// Регулярное выражение для целого числа
        /// </summary>
        private static readonly Regex _intRegex = new Regex("[^0-9]+");

        /// <summary>
        /// Регулярное выражение для вещественного числа
        /// </summary>
        private static readonly Regex _floatRegex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");

        /// <summary>
        /// Проверка текста на вещественное число
        /// </summary>
        /// <param name="parText">Текст</param>
        /// <returns>Является ли вещестенным числом</returns>
        public static bool IsFloatNumber(string parText)
        {
            return _floatRegex.IsMatch(parText);
        }

        /// <summary>
        /// Проверка текста на целое число
        /// </summary>
        /// <param name="parText">Текст</param>
        /// <returns>Является ли целым числом</returns>
        public static bool IsIntNumber(string parText)
        {
            return _intRegex.IsMatch(parText);
        }
    }
}
