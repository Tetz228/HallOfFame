namespace HallOfFame.Extensions.DataTypes
{
    /// <summary>
    ///     Класс расширения байтов.
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        ///     Проверка и обновление байтов.
        /// </summary>
        /// <param name="oldByte">Старый байт.</param>
        /// <param name="newByte">Новый байт.</param>
        /// <returns>Возвращает новый байт, если байты разные, иначе старый байт.</returns>
        public static byte ToCheckingAndUpdatingByte(this byte oldByte, byte newByte)
        {
            return oldByte != newByte ? newByte : oldByte;
        }
    }
}