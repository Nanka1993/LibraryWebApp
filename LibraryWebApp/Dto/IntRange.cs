namespace LibraryWebApp.Dto
{
    /// <summary>
    /// Диапазон
    /// </summary>
    public class IntRange
    {
        /// <summary>
        /// от включительно
        /// </summary>
        public int? Gte { get; set; }

        /// <summary>
        /// до включительно
        /// </summary>
        public int? Lte { get; set; }
    }
}
