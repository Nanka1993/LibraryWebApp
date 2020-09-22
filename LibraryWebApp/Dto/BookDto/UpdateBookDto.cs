namespace LibraryWebApp.Dto.BookDto
{
    public class UpdateBookDto
    {
        public string Editors { get; set; }
        public string Bbk { get; set; }
        public string Isbn { get; set; }
        public string PublishingOfficeName { get; set; }
        public string Udk { get; set; }
        public string Authors { get; set; }
        public string CountryName { get; set; }
        public bool IsOriginal { get; set; }
        public string CityName { get; set; }
        public int Year { get; set; }
        public int PageAmount { get; set; }
        public string Name { get; set; }
    }
}