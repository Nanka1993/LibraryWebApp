using Microsoft.AspNetCore.Mvc;
using System.Linq;
using LibraryWebApp.Models.Domain;
using LibraryWebApp.Services;
using LibraryWebApp.Services.FilteringServices;
using LibraryWebApp.Dto.Filters;
using LibraryWebApp.Dto;
using System.Collections.Generic;
using LibraryWebApp.Dto.BookDto;

namespace LibraryWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReaderController : ControllerBase
    {
        private readonly IReader<Book> _reader;


        private readonly IFilteringService<Book, BookFilter> _filteringService;


        public readonly IListViewer<BookDto, BookFilter> _listViewer;

        public BookReaderController(IReader<Book> reader, IFilteringService<Book, BookFilter> filteringService,
            IListViewer<BookDto, BookFilter> listViewer)
        {
            _reader = reader;
            _filteringService = filteringService;
            _listViewer = listViewer;
        }

        [HttpGet("GetFirstBook")]
        public Book GetFirstBook()
        {
            return _reader.GetItems().FirstOrDefault();
        }

        [HttpGet("GetBooksByPageRange")]
        public IEnumerable<Book> GetBooksByPageRange(int? gte, int? lte)
        {
            var filter = new BookFilter
            {
                PageRange = new IntRange
                {
                    Gte = gte,
                    Lte = lte
                }
            };
            return _filteringService.GetPublications(filter);
        }

        [HttpPost("GetBooksByFilter")]
        public IEnumerable<Book> GetBooksByFilter(BookFilter filter)
        {
            return _filteringService.GetPublications(filter);
        }

        [HttpPost("GetBooksByFilterSortPaging")]
        public IEnumerable<BookDto> GetBooksByFilterSortPaging(FilterSortPaging<BookFilter> filter)
        {
            return _listViewer.GetItems(filter);
        }
    }
}