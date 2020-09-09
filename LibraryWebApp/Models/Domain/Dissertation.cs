using LibraryWebApp.Enum;

namespace LibraryWebApp.Models.Domain
{
    /// <summary>
    /// Диссертация
    /// </summary>
    public class Dissertation : EditionUdk
    {
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
        public string ScientificSpecialtiy { get; set; }
        
        /// <summary>
        /// Тип диссертации
        /// </summary>
        public DissertationType @Type { get; set; }
    }
}
