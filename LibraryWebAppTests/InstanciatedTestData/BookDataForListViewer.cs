using LibraryWebApp.Dto.BookDto;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryWebApp.Models.Domain;

namespace LibraryWebAppTests.InstanciatedTestData
{
    public class BookDataForListViewer
    {
        public static IEnumerable<Book> GetItems()
        {
            return new[]
            {
                new Book
                {
                    Id = 1,
                    Name = "д",
                    IsOriginal = true,
                    PageAmount = 220,
                },
                new Book
                {
                    Id = 2,
                    Name = "г",
                    IsOriginal = true,
                    PageAmount = 500
                },
                new Book
                {
                    Id = 3,
                    Name = "в",
                    IsOriginal = true,
                    PageAmount = 450
                },
                new Book
                {
                    Id = 4,
                    Name = "б",
                    IsOriginal = false,
                    PageAmount = 290
                },
                new Book
                {
                    Id = 5,
                    Name = "а",
                    IsOriginal = true,
                    PageAmount = 650
                }

            };
        }
    }
}
