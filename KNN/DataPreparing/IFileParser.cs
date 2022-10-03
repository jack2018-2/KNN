using System.Collections.Generic;

namespace ConsoleApp10.DataPreparing
{
    /// <summary>
    /// Общий интерфейс файлового парсера
    /// </summary>
    public interface IFileParser
    {
        /// <summary>
        /// Собрать данные из указанного файла
        /// </summary>
        /// <typeparam name="T">Класс-обертка для содержимого</typeparam>
        /// <returns>Содержимое файла, упакованное в указанный класс-обертку</returns>
        IEnumerable<T> Parse<T>();
    }
}
