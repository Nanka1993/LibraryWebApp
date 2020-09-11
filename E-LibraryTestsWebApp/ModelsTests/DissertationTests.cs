using LibraryWebApp.Models.Domain;
using System;
using Xunit;

namespace E_LibraryTestsWebApp.ModelsTests
{
    public class DissertationTests
    {
        [Fact]
        private void Equals_InstancesDiffers_ReturnsFalse()
        {
            //arrange
            var sample1 = GetTestDissertation(1);
            var sample2 = GetTestDissertation(3);

            //act
            var actual = sample1.Equals(sample2);

            //assert
            Assert.False(actual);
        }


        [Theory]
        [InlineData(1, 3, false)]
        [InlineData(1, null, false)]
        [InlineData(1, 1, true)]
        [InlineData(1, 2, true)]
        [InlineData(2, 1, true)]
        private void Equals_InstancesFromParams_ReturnsExpected(int? index1, int? index2, bool expected)
        {
            //arrange
            var sample1 = GetTestDissertation(index1);
            var sample2 = GetTestDissertation(index2);

            //act
            var actual = sample1.Equals(sample2);

            //assert
            Assert.Equal(expected, actual);
        }

        private static Dissertation GetTestDissertation(int? index)
        {
            return index switch
            {
                null => null,
                1 => new Dissertation
                {
                    Name = "Математическое моделирование мехатронного комплекса бурильной установки",
                    Authors = "Калинин П.В.",
                },
                2 => new Dissertation
                {
                    Name = "Математическое моделирование мехатронного комплекса бурильной установки",
                    Authors = "Калинин П.В.",
                },
                3 => new Dissertation
                {
                    Name = "Исследование, разработка и внедркние высотных сооружений с гасителями колебаний",
                    Authors = "Остроумов Б.В.",
                },
                _ => throw new IndexOutOfRangeException(index.ToString())
            };
        }
    }
}
