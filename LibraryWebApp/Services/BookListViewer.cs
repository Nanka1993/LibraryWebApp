using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using LibraryWebApp.Constants;
using LibraryWebApp.Dto;
using LibraryWebApp.Dto.BookDto;
using LibraryWebApp.Dto.Filters;
using LibraryWebApp.Extensions;
using LibraryWebApp.Models.Domain;
using LibraryWebApp.Services.FilteringServices;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace LibraryWebApp.Services
{
    public class BookListViewer : IListViewer<BookDto, BookFilter>
    {
        private readonly IFilteringService<Book, BookFilter> _filteringService;

        private readonly IValidator<FilterSortPaging<BookFilter>> _validator;

        public BookListViewer(IFilteringService<Book, BookFilter> filteringService, IValidator<FilterSortPaging<BookFilter>> validator)
        {
            _filteringService = filteringService;
            _validator = validator;
        }


        public IEnumerable<BookDto> GetItems(
            FilterSortPaging<BookFilter> filterSortPaging)
        {
            _validator.ValidateAndThrow(filterSortPaging);
            var query = _filteringService.GetQuery(filterSortPaging.Filter);

            if (filterSortPaging.SortingFields != null)
            {
                query = filterSortPaging.SortingFields
                    .Aggregate(query, Sorting);
            }

            if (filterSortPaging.Pagination != null)
            {
                query = AddPagination(query, filterSortPaging.Pagination);
            }

            return query.AsEnumerable()
                .Select(x => ToDto(x));
        }

        private static IQueryable<Book> AddPagination(IQueryable<Book> query, Pagination pagination)
        {
            var actualSkip = pagination.Skip ?? CountOnPageLimits.DefaultSkip;
            var actualTake = pagination.Take ?? CountOnPageLimits.DefaultTake;
            var countTake = query.Count() - actualSkip;
            if (actualSkip >= query.Count())
            {
                throw new ValidationException($"Значение Skip должно быть меньше количества записей в запросе:{nameof(pagination.Skip)}>={query.Count()}");
            }

            if (actualTake > countTake || actualTake == 0)
            {
                return query.Skip(actualSkip)
                    .Take(countTake);
            }
            return query.Skip(actualSkip)
                .Take(actualTake);
        }

        private static BookDto ToDto(Book book)
        {
            return new BookDto
            {
                Name = book.Name,
                CountryName = book.CountryName,
                IsOriginal = book.IsOriginal,
                PublishingOfficeName = book.PublishingOfficeName,
                CityName = book.CityName,
                Year = book.Year,
                PageAmount = book.PageAmount,
                Editors = book.Editors,
                Bbk = book.Bbk,
                Udk = book.Udk,
                Isbn = book.Isbn,
                Authors = book.Authors,
            };
        }

        private IQueryable<Book> Sorting(IQueryable<Book> query, SortingField sortingField)
        {
            if (sortingField == null)
            {
                return query;
            }

            if (sortingField.Name == null && sortingField.IsDesc == null)
            {
                return query;
            }

            if (sortingField.IsDesc == null || sortingField.IsDesc == false)
            {
                return query.OrderBy(sortingField.Name);

            }
            return query.OrderByDescending(sortingField.Name);
        }

        public void Dispose()
        {
        }
    }
}