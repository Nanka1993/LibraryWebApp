using System;
using LibraryWebApp.Models.Domain;
using Xunit;

namespace LibraryWebAppTests.ModelsTests
{
    public class SynopsisOfThesisTests
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

        private static SynopsisOfThesis GetTestBook(int? index)
        {
            return index switch
            {
                null => null,
                1 => new SynopsisOfThesis
                {
                    Name = "Колебания строительных конструкций со случайными характеристиками",
                    Authors = "Зинина Н.Н.",
                },
                2 => new SynopsisOfThesis
                {
                    Name = "Колебания строительных конструкций со случайными характеристиками",
                    Authors = "Зинина Н.Н.",
                },
                3 => new SynopsisOfThesis
                {
                    Name = "О расчете виброзащитных устройств массивных фундаментов и башенных сооружений",
                    Authors = "Хлгатян З.М.",
                },
                _ => throw new IndexOutOfRangeException(index.ToString())
            };
        }
    }
}
