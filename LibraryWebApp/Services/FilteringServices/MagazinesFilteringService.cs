using LibraryWebApp.Dto.Filters;
using LibraryWebApp.Extensions;
using LibraryWebApp.Models.Domain;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWebApp.Services.FilteringServices
{
    public class MagazinesFilteringService : IFilteringService<Magazine, MagazineFilter>
    {
        private readonly IReader<Magazine> _reader;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MagazinesFilteringService(IReader<Magazine> reader)
        {
            _reader = reader;
        }

        public IEnumerable<Magazine> GetPublications(int yearEquals)
        {
            var filter = new MagazineFilter
            {
                YearEquals = yearEquals,
            };
            return GetPublications(filter);
        }

        public IEnumerable<Magazine> GetPublications(MagazineFilter filter)
        {
            var query = _reader.GetQuery();

            if (filter == null)
            {
                return query.AsEnumerable();
            }

            if (filter.YearEquals.HasValue)
            {
                query = query.Where(x => x.Year == filter.YearEquals);
            }

            if (!string.IsNullOrWhiteSpace(filter.NameContains))
            {
                var lowerTrimmed = filter.NameContains
                    .ToLowerInvariant()
                    .Trim();
                query = query.Where(x => x.Name
                    .Contains(lowerTrimmed));
            }

            return query.AddYearRangeFilter(filter.YearRange)
                .AsEnumerable();
        }
    }
}
