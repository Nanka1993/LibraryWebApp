using LibraryWebApp.Models.Domain;
using System;
using Xunit;
namespace ELibraryTests.ModelsTests
{
    public class BookTests
    {
        [Theory]
        [InlineData(1,2,true)]
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

        private static Book GetTestBook(int? index)
        {
            return index switch
            {
                null => null,
                1 => new Book
                {
                    Name = "Сборник задач по высшей математике. 1 курс",
                    Authors = "Письменный Д. Т.",
                },
                2 => new Book
                {
                    Name = "Сборник задач по высшей математике. 1 курс",
                    Authors = "Письменный Д. Т.",
                },
                3 => new Book
                {
                    Name = "Механика стержней: Учеб. для вузов. В 2-х ч. Ч. 1. Статика",
                    Authors = "Светлицкий В.А.",
                },
                _ => throw new IndexOutOfRangeException(index.ToString())
            };
        }
    }
}