namespace LibraryWebApp.Models.Domain
{
    /// <summary>
    /// Автореферат
    /// </summary>
    public class SynopsisOfThesis : EditionUdk
    {
        /// <summary>
        /// Диссертация
        /// </summary>
        public Dissertation Dissertation { get; set; }

        /// <summary>
        /// Учебное заведение (организация)
        /// </summary>
        public string Institution { get; set; }

        /// <summary>
        /// Научный руководитель
        /// </summary>
        public string AcademicAdviser { get; set; }

        /// <summary>
        /// Научная специальность
        /// </summary>
        public string ScientificSpeciality { get; set; }
    }
}
