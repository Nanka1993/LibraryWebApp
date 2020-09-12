using ELibraryTests.InstanciatedTestData;
using LibraryWebApp.Dto;
using LibraryWebApp.Dto.Filters;
using LibraryWebApp.Extensions;
using LibraryWebApp.Models.Domain;
using System.Linq;
using Xunit;

namespace ELibraryTests.ExtensionsTests
{
    public class RangeExtensionsTests
    {
        private static readonly IQueryable<Book> books = BookData.GetItems()
            .AsQueryable();
        private static readonly IQueryable<Magazine> magazines = MagazineData.GetItems()
            .AsQueryable();

        [Fact]
        public void AddYearRangeFilter_FilterIsNull_ReturnsNotNull()
        {
            //act
            var actual = books.AddYearRangeFilter(null);

            //assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void AddPageRangeFilter_FilterIsNull_ReturnsNotNull()
        {
            //act
            var actual = magazines.AddPageRangeFilter(null);

            //assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void AddYearRangeFilter_GteNullAndLteNull_ReturnsFullList()
        {
            //arrange
            var expectedCount = magazines.Count();
            var filter = new MagazineFilter
            {
                YearRange = new IntRange
                {

                    Gte = null,
                    Lte = null
                }
            };
            //act
            var actual = magazines.AddPageRangeFilter(filter.YearRange);

            //assert
            Assert.Equal(expectedCount, actual.Count());
        }

        [Theory]
        [InlineData(250, null, 2)]
        [InlineData(null, 450, 2)]
        [InlineData(250, 450, 1)]
        [InlineData(null, null, 3)]
        [InlineData(450, 450, 1)]

        public void AddPageRangeFilter_PageRangeFromParam_ReturnsCount(int? gte, int? lte, int? expectedCount)
        {
            //arrange
            var filter = new BookFilter
            {
                PageRange = new IntRange
                {
                    Gte = gte,
                    Lte = lte
                }
            };
            //act
            var actual = books.AddPageRangeFilter(filter.PageRange);

            //assert
            Assert.Equal(expectedCount, actual.Count());
        }

        [Theory]
        [InlineData(2019, null, 2)]
        [InlineData(null, 2019, 2)]
        [InlineData(2019, 2020, 2)]
        [InlineData(null, null, 3)]
        [InlineData(2018, 2018, 1)]

        public void AddYearRangeFilter_YarRangeFromParam_ReturnsCount(int? gte, int? lte, int? expectedCount)
        {
            //arrange
            var filter = new MagazineFilter
            {
                YearRange = new IntRange
                {
                    Gte = gte,
                    Lte = lte
                }
            };
            //act
            var actual = magazines.AddYearRangeFilter(filter.YearRange);

            //assert
            Assert.Equal(expectedCount, actual.Count());
        }
    }
}
