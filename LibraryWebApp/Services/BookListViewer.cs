using System;
using System.Collections.Generic;
using System.Linq;
using LibraryWebApp.Constants;
using LibraryWebApp.Dto;
using LibraryWebApp.Dto.BookDto;
using LibraryWebApp.Dto.Filters;
using LibraryWebApp.Extensions;
using LibraryWebApp.Models.Domain;
using LibraryWebApp.Services.FilteringServices;

namespace LibraryWebApp.Services
{
    public class BookListViewer : IListViewer<UpdateBookDto, BookFilter>
    {
        private readonly IFilteringService<Book, BookFilter> _filteringService;

        public BookListViewer(IFilteringService<Book, BookFilter> filteringService)
        {
            _filteringService = filteringService;
        }


        public IEnumerable<UpdateBookDto> GetItems(
            FilterWithPaginationAndSorting<BookFilter> filterWithPaginationAndSorting)
        {
            if (filterWithPaginationAndSorting == null)
            {
                throw new ArgumentNullException(nameof(FilterWithPaginationAndSorting<BookFilter>));
            }

            var query = _filteringService.GetQuery(filterWithPaginationAndSorting.Filter);
            query = filterWithPaginationAndSorting.SortingFields
                .Aggregate(query, Sorting);

            query = AddPagination(query, filterWithPaginationAndSorting.Pagination);
            return query.AsEnumerable()
                .Select(x => ToDto(x));
        }

        private IQueryable<Book> AddPagination(IQueryable<Book> query, Pagination pagination)
        {
            return query.Skip(pagination?.Skip ?? CountOnPageLimits.DefaultSkip)
                .Take(pagination?.Take ?? CountOnPageLimits.DefaultTake);
        }

        private static UpdateBookDto ToDto(Book book)
        {
            return new UpdateBookDto
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
            return sortingField.IsDesc? query.OrderByDescending(sortingField.Name): query.OrderBy(sortingField.Name);
        }

        public void Dispose()
        {
        }
    }
}