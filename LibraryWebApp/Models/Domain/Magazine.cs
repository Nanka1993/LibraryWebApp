using LibraryWebApp.Enum;

namespace LibraryWebApp.Models.Domain
{
    /// <summary>
    /// Журнал
    /// </summary>
    public class Magazine : AbstractPublication
    {
        /// <summary>
        /// Номер журнала
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Классификатор ISSN
        /// </summary>
        public string Issn { get; set; }

        /// <summary>
        /// Рубрикатор ГРНТИ
        /// </summary>
        public string RubricatorName { get; set; }

        /// <summary>
        /// Включён в Web Of Science
        /// </summary>
        public bool IsIncludedInWebOfScience { get; set; }

        /// <summary>
        /// Включён в список ВАК
        /// </summary>
        public bool IsIncludedVak { get; set; }

        /// <summary>
        /// Сведения о включении в РИНЦ
        /// </summary>
        public  string InclusionInformationInRints { get; set; }

        /// <summary>
        /// Сведения о включении в список Scopus
        /// </summary>
        public string InclusionInformationInScopus { get; set; }

        /// <summary>
        /// Издательство
        /// </summary>
        public string PublishingOfficeName { get; set; }

        /// <summary>
        /// Версия журнала
        /// </summary>
        public MagazineType @Type { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = obj as Magazine;
            return Name == other?.Name && Issn == other?.Issn && Number==other?.Number && Year==other?.Year;
        }
    }
}
