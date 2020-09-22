using System;
using LibraryWebApp.Models.Domain;
using Xunit;

namespace LibraryWebAppTests.ModelsTests
{
    public class ArticleTests
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

        private static Article GetTestBook(int? index)
        {
            return index switch
            {
                null => null,
                1 => new Article
                {
                    Name = "Оценка сооружений на возникновение галлопирвания",
                    Authors = "Рутман Ю.Л., Мелешко В.А.",
                },
                2 => new Article
                {
                    Name = "Оценка сооружений на возникновение галлопирвания",
                    Authors = "Рутман Ю.Л., Мелешко В.А.",
                },
                3 => new Article
                {
                    Name = "Применение математического моделирования в архитектурном проектировании высотных зданий",
                    Authors = "ЖИЛИН С.С., МИСЮРА Н.Е., МИТЮШОВ Е.А",
                },
                _ => throw new IndexOutOfRangeException(index.ToString())
            };
        }
    }
}
