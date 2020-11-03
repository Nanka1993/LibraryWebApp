using LibraryWebApp.Dto.Filters;
using LibraryWebApp.Extensions;
using LibraryWebApp.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using LibraryWebApp.Dto;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace LibraryWebApp.Services.FilteringServices
{
    public class BooksFilteringService : IFilteringService<Book, BookFilter>
    {

        private readonly IValidator<BookFilter> _validator;

        private readonly IReader<Book> _reader;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public BooksFilteringService(IReader<Book> reader, IValidator<BookFilter> validator)
        {
            _reader = reader;
            _validator = validator;
        }

        public IEnumerable<Book> GetPublications(BookFilter filter)
        {
            var query = GetQuery(filter);
            return query.AsEnumerable();
        }

        public IQueryable<Book> GetQuery(BookFilter filter)
        {
            var query = _reader.GetQuery();

            if (filter == null)
            {
                return query;
            }
            _validator.ValidateAndThrow(filter);

            if (filter.PageRange == null && filter.EqualsToIsOriginal == null)
            {
                return query;
            }

            if (filter.PageRange == null && filter.EqualsToIsOriginal != null)
            {
                return query.Where(x => x.IsOriginal == filter.EqualsToIsOriginal)
                    .AddPageRangeFilter(filter.PageRange);
            }

            if (filter.PageRange.Gte.HasValue && filter.PageRange.Lte.HasValue)
            {
                query = query.Where(x => x.PageAmount >= filter.PageRange.Gte
                                         && x.PageAmount <= filter.PageRange.Lte);
            }

            if (filter.PageRange.Gte.HasValue)
            {
                query = query.Where(x => x.PageAmount >= filter.PageRange.Gte);
            }

            if (filter.PageRange.Lte.HasValue)
            {
                query = query.Where(x => x.PageAmount <= filter.PageRange.Lte);
            }

            if (filter.EqualsToIsOriginal == null)
            {
                return query;
            }

            return query.Where(x => x.IsOriginal == filter.EqualsToIsOriginal)
                .AddPageRangeFilter(filter.PageRange);
        }
        
    }
}