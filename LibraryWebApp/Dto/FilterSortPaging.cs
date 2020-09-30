using System.Collections.Generic;

namespace LibraryWebApp.Dto
{
    public class FilterSortPaging<T>
    {
        public T Filter { get; set; }

        public Pagination Pagination { get; set; }

        public IEnumerable<SortingField> SortingFields { get; set; }
    }
}