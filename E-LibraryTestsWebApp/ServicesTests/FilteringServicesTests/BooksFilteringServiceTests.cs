using E_LibraryTestsWebApp.InstanciatedTestData;
using LibraryWebApp.Dto;
using LibraryWebApp.Dto.Filters;
using LibraryWebApp.Models.Domain;
using LibraryWebApp.Services;
using LibraryWebApp.Services.FilteringServices;
using Moq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace E_LibraryTestsWebApp.ServicesTests.FilteringServicesTests
{
    public class BooksFilteringServiceTests
    {
        private readonly IFilteringService<Book, BookFilter> _service;

        private static readonly IEnumerable<Book> books = BookData.GetItems();

        public BooksFilteringServiceTests()
        {
            var mock = new Mock<IReader<Book>>();
            mock.Setup(a => a.GetQuery())
                .Returns(books.AsQueryable);

            _service = new BooksFilteringService(mock.Object);
        }

        [Fact]
        public void GetPublications_FilterIsNull_ReturnsNotNull()
        {
            //act
            var actual = _service.GetPublications(null);

            //assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void GetPublications_FilterIsNull_ReturnsFullList()
        {
            //arrange
            var expectedCount = books.Count();

            //act
            var actual = _service.GetPublications(null);

            //assert
            Assert.Equal(expectedCount, actual.Count());
        }

        [Fact]
        public void GetPublications_IsOriginalToFalse_ReturnsOneItem()
        {
            //arrange
            var expectedId = 3;
            var filter = new BookFilter
            {
                EqualsToIsOriginal = false
            };

            //act
            var actual = _service.GetPublications(filter).FirstOrDefault();

            //assert
            Assert.Equal(expectedId, actual?.Id);
        }

        [Fact]
        public void GetPublications_PageAmountGte400Lte480_ReturnsOneItem()
        {
            //arrange
            var expectedId = 3;
            var filter = new BookFilter
            {
                PageRange = new IntRange
                {
                    Gte = 400,
                    Lte = 480
                }
            };

            //act
            var actual = _service.GetPublications(filter).FirstOrDefault();

            //assert
            Assert.Equal(expectedId, actual?.Id);
        }

        [Fact]
        public void GetPublications_IsOriginalFalseAndPageAmountGte500Lte600_ReturnsOneItem()
        {
            //arrange
            var expectedId = 2;
            var filter = new BookFilter
            {
                EqualsToIsOriginal = true,
                PageRange = new IntRange
                {
                    Gte = 500,
                    Lte = 600
                }
            };

            //act
            var actual = _service.GetPublications(filter).FirstOrDefault();

            //assert
            Assert.Equal(expectedId, actual?.Id);
        }

        [Fact]
        public void GetPublications_GteIsNegative_ThrowsValidationException()
        {
            //arrange
            var filter = new BookFilter
            {
                PageRange = new IntRange
                {
                    Gte = -100,
                }
            };

            //act

            //assert
            Assert.Throws<ValidationException>(() => _service.GetPublications(filter));
        }

        [Fact]
        public void GetPublications_LteIsNegative_ThrowsValidationException()
        {
            //arrange
            var filter = new BookFilter
            {
                PageRange = new IntRange
                {
                    Lte = -100
                }
            };

            //act

            //assert
            Assert.Throws<ValidationException>(() => _service.GetPublications(filter));
        }

        [Fact]
        public void GetPublications_LteIsLessThanGte_ThrowsValidationException()
        {
            //arrange
            var filter = new BookFilter
            {
                PageRange = new IntRange
                {
                    Gte = 150,
                    Lte = 100
                }
            };

            //act

            //assert
            Assert.Throws<ValidationException>(() => _service.GetPublications(filter));
        }

        [Fact]
        public void GetPublications_LteEqualToZero_ThrowsValidationException()
        {
            //arrange
            var filter = new BookFilter
            {
                PageRange = new IntRange
                {
                    Gte = 150,
                    Lte = 0
                }
            };

            //act

            //assert
            Assert.Throws<ValidationException>(() => _service.GetPublications(filter));
        }

        [Fact]
        public void GetPublications_LteEqualGte_ThrowsValidationException()
        {
            //arrange
            var expectedId = 1;
            var filter = new BookFilter
            {
                PageRange = new IntRange
                {
                    Gte = 220,
                    Lte = 220
                }
            };

            //act
            var actual = _service.GetPublications(filter).FirstOrDefault();

            //assert
            Assert.Equal(expectedId, actual?.Id);
        }

        [Fact]
        public void AddPageRangeFilter_PageRangeNull_ReturnsFullList()
        {
            //arrange
            var expectedCount = books.Count();
            var filter = new BookFilter
            {
                PageRange = null
            };

            //act
            var actual = _service.GetPublications(filter);

            //assert
            Assert.Equal(expectedCount, actual.Count());
        }
        [Fact]
        public void AddPageRangeFilter_PageRangeNullAnEqualsToIsOriginalNull_ReturnsFullList()
        {
            //arrange
            var expectedCount = books.Count();
            var filter = new BookFilter
            {
                PageRange = null,
                EqualsToIsOriginal = null
            };

            //act
            var actual = _service.GetPublications(filter);

            //assert
            Assert.Equal(expectedCount, actual.Count());
        }

        [Fact]
        public void AddPageRangeFilter_PageRangeNullIsOriginalTtue_ReturnsTwoItems()
        {
            //arrange

            var filter = new BookFilter
            {
                PageRange = null,
                EqualsToIsOriginal = true
            };

            //act
            var actual = _service.GetPublications(filter);

            //assert
            Assert.Equal(2, actual.Count());
        }

        [Fact]
        public void AddPageRangeFilter_GteNullAndLteNull_ReturnsTwoItems()
        {
            //arrange

            var filter = new BookFilter
            {
                PageRange = new IntRange
                {
                    Gte = null,
                    Lte = null
                },
                EqualsToIsOriginal = true
            };

            //act
            var actual = _service.GetPublications(filter);

            //assert
            Assert.Equal(2, actual.Count());
        }

    }
}
