namespace LibraryWebApp.Dto.Filters
{
    /// <summary>
    /// Модель фильтра для журнала
    /// </summary>
    public class MagazineFilter
    {
        /// <summary>
        /// Фильтрация по году
        /// </summary>
        public int? YearEquals { get; set; }

        /// <summary>
        /// Фильтрация по названию
        /// </summary>
        public string NameContains { get; set; }

        /// <summary>
        /// Фильтрация по диапазону лет
        /// </summary>
        public IntRange YearRange { get; set; }
    }
}
