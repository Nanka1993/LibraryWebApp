namespace LibraryWebApp.Dto.Filters
{
    /// <summary>
    /// Модель фильтра книг
    /// </summary>
    public class BookFilter
    {
        /// <summary>
        /// Является ли оригиналом
        /// </summary>
        public bool? EqualsToIsOriginal { get; set; }

        /// <summary>
        /// Фильтрация по диапазону количества страниц
        /// </summary>
        public IntRange PageRange { get; set; }

    }
}
