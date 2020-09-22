using System;
using LibraryWebApp.Models.Domain;
using Xunit;

namespace LibraryWebAppTests.ModelsTests
{
    public class MagazineTests
    {
        [Theory]
        [InlineData(1, 2, true)]
        [InlineData(1, 3, false)]
        [InlineData(2, 3, false)]
        [InlineData(1, null, false)]
        [InlineData(1, 1, true)]
        [InlineData(2, 1, true)]
        private void Equals_InstancesFromParams_ReturnExpected(int? index1, int? index2, bool expected)
        {
            //arrange
            var sample1 = GetTestBook(index1);
            var sample2 = GetTestBook(index2);

            //act
            var actual = sample1.Equals(sample2);

            //assert
            Assert.Equal(expected, actual);
        }

        private static Magazine GetTestBook(int? index)
        {
            return index switch
            {
                null => null,
                1 => new Magazine
                {
                    Name = "Строительство: наука и образование",
                    Issn = "2305-5502",
                    Number = 1,
                    Year = 2020,
                },
                2 => new Magazine
                {
                    Name = "Строительство: наука и образование",
                    Issn = "2305-5502",
                    Number = 1,
                    Year = 2020,
                },
                3 => new Magazine
                {
                    Name = "Высотные сооружения",
                    Issn = "1992-2124",
                    Number = 4,
                    Year = 2016,
                },
                _ => throw new IndexOutOfRangeException(index.ToString())
            };
        }

    }
}
