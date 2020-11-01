namespace LibraryWebApp.Dto
{
    public class Pagination
    {
        /// <summary>
        /// Количество пропущенных элементов
        /// </summary>
        public int? Skip { get; set; }

        /// <summary>
        /// Количество получаемых элементов
        /// </summary>
        public int? Take { get; set; }

    }
}
