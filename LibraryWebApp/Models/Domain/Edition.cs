namespace LibraryWebApp.Models.Domain
{
    /// <summary>
    /// Публикации с авторами
    /// </summary>
    public abstract class Edition : AbstractPublication
    {
        /// <summary>
        /// Автор(ы)
        /// </summary>
        public string Authors { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = obj as Edition;
            return Name == other?.Name && Authors == other?.Authors;
        }
    }
}
