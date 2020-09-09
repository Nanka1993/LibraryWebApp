namespace LibraryWebApp.Models.Domain
{
    public class Article : IdName
    {
        /// <summary>
        /// Принадлежность журналу
        /// </summary>
        public Magazine Magazine { get; set; }

        /// <summary>
        /// Автор(ы)
        /// </summary>
        public string Authors { get; set; }

        /// <summary>
        /// Номер страницы С
        /// </summary>
        public int PageFrom { get; set; }

        /// <summary>
        /// Номер страницы ПО
        /// </summary>
        public int PageTo { get; set; }

        /// <summary>
        /// Индекс Универсальной десятичной классификации
        /// </summary>
        public string Udk { get; set; }

        /// <summary>
        /// В оригинале (язык)
        /// </summary>
        public bool IsOriginal { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = obj as Article;
            return Name == other?.Name && Authors == other?.Authors;
        }
    }
}
