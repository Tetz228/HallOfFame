namespace HallOfFame.Extensions.DataTypes
{
    /// <summary>
    ///     Класс расширения строки.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Проверка и обновление строк.
        /// </summary>
        /// <param name="oldString">Старая строка.</param>
        /// <param name="newString">Новая строка.</param>
        /// <returns>Возвращает новую строку, если строки разные, иначе старую строку.</returns>
        public static string ToCheckingAndUpdatingString(this string oldString, string newString)
        {
            return oldString != newString ? newString : oldString;
        }
    }
}