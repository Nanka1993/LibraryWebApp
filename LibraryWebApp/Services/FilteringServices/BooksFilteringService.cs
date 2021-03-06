﻿using LibraryWebApp.Dto.Filters;
using LibraryWebApp.Extensions;
using LibraryWebApp.Models.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LibraryWebApp.Services.FilteringServices
{
    public class BooksFilteringService : IFilteringService<Book, BookFilter>
    {
        private readonly IReader<Book> _reader;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public BooksFilteringService(IReader<Book> reader)
        {
            _reader = reader;
        }

        public IEnumerable<Book> GetPublications(BookFilter filter)
        {
            ValidateFilterAndThrow(filter);
            var query = _reader.GetQuery();

            if (filter == null)
            {
                return query.AsEnumerable();
            }

            if (filter.PageRange == null && filter.EqualsToIsOriginal == null)
            {
                return query.AsEnumerable();
            }

            if (filter.PageRange == null && filter.EqualsToIsOriginal != null)
            {
                return query.Where(x => x.IsOriginal == filter.EqualsToIsOriginal)
                    .AddPageRangeFilter(filter.PageRange)
                    .AsEnumerable();
            }

            if (filter.PageRange.Gte.HasValue && filter.PageRange.Gte.HasValue)
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
                return query.AsEnumerable();
            }

            return query.Where(x => x.IsOriginal == filter.EqualsToIsOriginal)
                .AddPageRangeFilter(filter.PageRange)
                .AsEnumerable();

        }

        private static void ValidateFilterAndThrow(BookFilter filter)
        {
            if (filter == null)
            {
                return;
            }
            if (filter.PageRange == null)
            {
                return;
            }
            if (filter.PageRange.Gte == null && filter.PageRange.Lte == null)
            {
                return;
            }

            var rangeIsOk = (filter.PageRange.Gte ?? 0) <= (filter.PageRange.Lte ?? int.MaxValue);
            var gteIsOk = filter.PageRange.Gte.HasValue && filter.PageRange.Gte >= 0;
            var lteIsOk = filter.PageRange.Lte.HasValue && filter.PageRange.Lte > 0;

            if (!rangeIsOk || !gteIsOk || !lteIsOk)
            {
                throw new ValidationException(
                    $"Некорректно задан диапазон фильтра:{nameof(filter.PageRange.Gte)}={filter.PageRange.Gte},{nameof(filter.PageRange.Lte)}={filter.PageRange.Lte}");
            }
        }
    }
}
