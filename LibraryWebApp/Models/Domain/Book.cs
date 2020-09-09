namespace LibraryWebApp.Models.Domain
{
    /// <summary>
    /// Книга
    /// </summary>
    public class Book : EditionUdk
    {
        /// <summary>
        /// Редакторы
        /// </summary>
        public string Editors { get; set; }

        /// <summary>
        /// Индекс Библиотечно-библиографической классификации
        /// </summary>
        public string Bbk { get; set; }

        /// <summary>
        /// Международный стандартный книжный номер
        /// </summary>
        public string Isbn { get; set; }

        /// <summary>
        /// Издательство
        /// </summary>
        public string PublishingOfficeName { get; set; }
    }
}
