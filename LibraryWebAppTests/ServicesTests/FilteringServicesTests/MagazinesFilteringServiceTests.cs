using LibraryWebApp.Dto.Filters;
using LibraryWebApp.Models.Domain;
using LibraryWebApp.Services;
using LibraryWebApp.Services.FilteringServices;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ELibraryTests.ServicesTests.FilteringServicesTests
{
    public class MagazinesFilteringServiceTests
    {
        private readonly IFilteringService<Magazine, MagazineFilter> _service;

        public MagazinesFilteringServiceTests()
        {
            var mock = new Mock<IReader<Magazine>>();
            mock.Setup(a => a.GetQuery())
                .Returns(GetTestData().AsQueryable);

            _service = new MagazinesFilteringService(mock.Object);
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
            var expectedCount = GetTestData().Count();

            //act
            var actual = _service.GetPublications(null);

            //assert
            Assert.Equal(expectedCount, actual.Count());
        }

        [Fact]
        public void GetPublications_YearEqualsTo2020_ReturnsOneItem()
        {
            //arrange
            var expectedId = 1;
            var filter = new MagazineFilter
            {
                YearEquals = 2020
            };

            //act
            var actual = _service.GetPublications(filter).FirstOrDefault();

            //assert
            Assert.Equal(expectedId, actual?.Id);
        }

        [Fact]
        public void GetPublications_NameContainsBuildings_ReturnsTwoItems()
        {
            //arrange
            var filter = new MagazineFilter
            {
                NameContains = "здания"
            };

            //act
            var actual = _service.GetPublications(filter);

            //assert
            Assert.NotNull(actual);
            Assert.Equal(2, actual.Count());
        }

        [Fact]
        public void GetPublications_YearEqualsTo2020AndNameContainsBuildings_ReturnsOneItem()
        {
            var filter = new MagazineFilter
            {
                YearEquals = 2019,
                NameContains = "здания"
            };

            //act
            var actual = _service.GetPublications(filter);

            //assert
            Assert.Equal(1, actual.Count());
        }

        private static IEnumerable<Magazine> GetTestData()
        {
            return new[]
            {
                new Magazine
                {
                    Id = 1,
                    Year = 2020,
                    Name = "Строительство"
                },
                new Magazine
                {
                    Id = 2,
                    Year = 2019,
                    Name = "Высотные здания"
                },
                new Magazine
                {
                    Id = 3,
                    Year = 2018,
                    Name = "Низенькие здания"
                }
            };
        }
    }
}