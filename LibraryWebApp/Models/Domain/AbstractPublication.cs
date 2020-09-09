namespace LibraryWebApp.Models.Domain
{
    public abstract class AbstractPublication : IdName
    {
        /// <summary>
        /// Страна
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// В оригинале (язык)
        /// </summary>
        public bool IsOriginal { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Год издания
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Количество страниц
        /// </summary>
        public int PageAmount { get; set; }
    }
}