using System;
using System.Collections.Generic;
using System.Linq;
using LibraryWebApp.Dto;
using LibraryWebApp.Dto.BookDto;
using LibraryWebApp.Dto.Filters;
using LibraryWebApp.Models.Domain;
using LibraryWebApp.Services;
using LibraryWebApp.Services.FilteringServices;
using LibraryWebApp.Services.ValidationService;
using LibraryWebAppTests.InstanciatedTestData;
using Moq;
using Xunit;

namespace LibraryWebAppTests.ServicesTests
{
    public class BookListViewerTests
    {
        private readonly IListViewer<BookDto, BookFilter> _listViewer;

        private static readonly IEnumerable<Book> Books = BookDataForListViewer.GetItems();

        private const bool IsOriginal = true;
        private const int Gte = 200;
        private const int Lte = 600;

        public BookListViewerTests()
        {
            var filteringServiceMock = new Mock<IFilteringService<Book, BookFilter>>();
            filteringServiceMock.Setup(a => a.GetQuery(new BookFilter
                {
                    EqualsToIsOriginal = IsOriginal,
                    PageRange = new IntRange
                    {
                        Gte = Gte,
                        Lte = Lte
                    }
                }))
                .Returns(Books
                    .Where(x => x.IsOriginal && x.PageAmount >= Gte && x.PageAmount <= Lte)
                    .AsQueryable);
            var bookValidator = new BookFilterValidator();
            var sortingValidator = new SortingValidator();
            var bfspValidator = new BookFilterSortPagingValidator(bookValidator, sortingValidator);
            _listViewer = new BookListViewer(filteringServiceMock.Object, bfspValidator);
        }

        [Fact]
        public void GetItems_FilterSortPagingIsNull_ThrowArgNullException()
        {
            //arrange

            //act

            //assert

            Assert.Throws<ArgumentNullException>(() => _listViewer.GetItems(null));
        }

        [Fact]
        public void GetItems_FilterPositiveCasesSortingFieldAndPagingNull_ReturnsData()
        {
            //arrange
            var filter = new FilterSortPaging<BookFilter>
            {
                Filter = new BookFilter
                {
                    EqualsToIsOriginal = IsOriginal,
                    PageRange = new IntRange
                    {
                        Gte = Gte,
                        Lte = Lte
                    }
                },
                SortingFields = new SortingField[] { },
                Pagination = null
            };

            //act

            var actual = _listViewer.GetItems(filter).Count();

            //assert
            Assert.Equal(3, actual);
        }

        [Fact]
        public void GetItems_FilterPositiveCasesSortingFieldsListAndPagingNull_ReturnsData()
        {
            //arrange
            var filter = new FilterSortPaging<BookFilter>
            {
                Filter = new BookFilter
                {
                    EqualsToIsOriginal = IsOriginal,
                    PageRange = new IntRange
                    {
                        Gte = Gte,
                        Lte = Lte
                    }
                },
                SortingFields = null,
                Pagination = null
            };

            //act

            var actual = _listViewer.GetItems(filter).Count();

            //assert
            Assert.Equal(3, actual);
        }

        [Fact]
        public void GetItems_FilterPositiveCasesSortingFieldsNameAndIsDescAndPagingNull_ReturnsData()
        {
            //arrange
            var filter = new FilterSortPaging<BookFilter>
            {
                Filter = new BookFilter
                {
                    EqualsToIsOriginal = IsOriginal,
                    PageRange = new IntRange
                    {
                        Gte = Gte,
                        Lte = Lte
                    }
                },
                SortingFields = new List<SortingField>
                {
                    new SortingField
                    {
                        IsDesc = null,
                        Name = null
                    },
                },
                Pagination = null
            };

            //act

            //assert
            Assert.Throws<FluentValidation.ValidationException>(() => _listViewer.GetItems(filter));
        }

        [Fact]
        public void GetItems_FilterPositiveCasesSortByNameIsDescFalsePagingNull_ReturnsData()
        {
            //arrange
            var filter = new FilterSortPaging<BookFilter>
            {
                Filter = new BookFilter
                {
                    EqualsToIsOriginal = IsOriginal,
                    PageRange = new IntRange
                    {
                        Gte = Gte,
                        Lte = Lte
                    }
                },
                SortingFields = new List<SortingField>
                {
                    new SortingField
                    {
                        IsDesc = false,
                        Name = "Name"
                    },
                },
                Pagination = null
            };

            //act

            var actual = _listViewer.GetItems(filter).ToList();

            //assert
            Assert.Equal(Books.ElementAt(0).Name, actual.ElementAt(2).Name);
            Assert.Equal(Books.ElementAt(2).Name, actual.ElementAt(0).Name);
        }

        [Fact]
        public void GetItems_FilterPositiveCasesSortNullPagingSkip0Take2_ReturnsData()
        {
            //arrange
            var filter = new FilterSortPaging<BookFilter>
            {
                Filter = new BookFilter
                {
                    EqualsToIsOriginal = IsOriginal,
                    PageRange = new IntRange
                    {
                        Gte = Gte,
                        Lte = Lte
                    }
                },
                SortingFields = null,
                Pagination = new Pagination
                {
                    Skip = 0,
                    Take = 2
                },
            };

            //act

            var actual = _listViewer.GetItems(filter).Count();

            //assert
            Assert.Equal(2, actual);
        }

        [Fact]
        public void GetItems_FilterPositiveCasesSortNullPagingSkip2Take1_ReturnsData()
        {
            //arrange
            var filter = new FilterSortPaging<BookFilter>
            {
                Filter = new BookFilter
                {
                    EqualsToIsOriginal = IsOriginal,
                    PageRange = new IntRange
                    {
                        Gte = Gte,
                        Lte = Lte
                    }
                },
                SortingFields = null,
                Pagination = new Pagination
                {
                    Skip = 2,
                    Take = 1
                },
            };

            //act

            var actual = _listViewer.GetItems(filter);

            //assert
            Assert.Equal(Books.ElementAt(2).Name, actual.ElementAt(0).Name);
        }

        [Fact]
        public void GetItems_FilterPositiveCasesSortNullPagingSkip2Take2_ReturnsData()
        {
            //arrange
            var filter = new FilterSortPaging<BookFilter>
            {
                Filter = new BookFilter
                {
                    EqualsToIsOriginal = IsOriginal,
                    PageRange = new IntRange
                    {
                        Gte = Gte,
                        Lte = Lte
                    }
                },
                SortingFields = null,
                Pagination = new Pagination
                {
                    Skip = 2,
                    Take = 2
                },
            };

            //act

            var actual = _listViewer.GetItems(filter);

            //assert
            Assert.Single(actual);
        }

        [Fact]
        public void GetItems_FilterNegativeCaseSort()
        {
            //arrange
            var filter = new FilterSortPaging<BookFilter>
            {
                Filter = new BookFilter
                {
                    EqualsToIsOriginal = IsOriginal,
                    PageRange = new IntRange
                    {
                        Gte = Gte,
                        Lte = Lte
                    }
                },
                SortingFields = null,
                Pagination = new Pagination
                {
                    Skip = 2,
                    Take = 2
                },
            };

            //act

            var actual = _listViewer.GetItems(filter);

            //assert
            Assert.Single(actual);
        }

        [Fact]
        public void GetItems_FilterNegativeCaseSortIsDescNullNameNullAndPaginationSkipNegative()
        {
            //arrange
            var filter = new FilterSortPaging<BookFilter>
            {
                Filter = new BookFilter
                {
                    EqualsToIsOriginal = IsOriginal,
                    PageRange = new IntRange
                    {
                        Gte = Gte,
                        Lte = Lte
                    }
                },
                SortingFields = new List<SortingField>
                {
                    new SortingField
                    {
                        IsDesc = null,
                        Name = null
                    },
                },
                Pagination = new Pagination
                {
                    Skip = -2,
                    Take = 2,
                },
            };

            //act

            //assert
            Assert.Throws<FluentValidation.ValidationException>(() => _listViewer.GetItems(filter));
        }
    }
}