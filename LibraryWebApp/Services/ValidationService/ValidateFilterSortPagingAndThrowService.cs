using System;
using LibraryWebApp.Dto;
using LibraryWebApp.Dto.Filters;
using LibraryWebApp.Models.Domain;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace LibraryWebApp.Services.ValidationService
{
    public class ValidateFilterSortPagingAndThrowService
    {
        public void ValidateAndThrow(FilterSortPaging<BookFilter> filterSortPaging)
        {
            var filter = filterSortPaging.Filter;
            if (filterSortPaging == null)
            {
                throw new ArgumentNullException(nameof(FilterSortPaging<BookFilter>));
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
            var gteIsOk = (filter.PageRange.Gte.HasValue && filter.PageRange.Gte >= 0) ||
                          !filter.PageRange.Gte.HasValue;
            var lteIsOk = (filter.PageRange.Lte.HasValue && filter.PageRange.Lte > 0) || !filter.PageRange.Lte.HasValue;

            if (!rangeIsOk || !gteIsOk || !lteIsOk)
            {
                throw new ValidationException(
                    $"Некорректно задан диапазон фильтра:{nameof(filter.PageRange.Gte)}={filter.PageRange.Gte},{nameof(filter.PageRange.Lte)}={filter.PageRange.Lte}");
            }
        }
    }
}