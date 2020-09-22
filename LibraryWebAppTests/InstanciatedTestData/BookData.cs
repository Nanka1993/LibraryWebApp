﻿using System.Collections.Generic;
using LibraryWebApp.Models.Domain;

namespace LibraryWebAppTests.InstanciatedTestData
{
    public static class BookData
    {
        public static IEnumerable<Book> GetItems()
        {
            return new[]
            {
                new Book
                {
                    Id = 1,
                    IsOriginal = true,
                    PageAmount = 220,
                },
                new Book
                {
                    Id = 2,
                    IsOriginal = true,
                    PageAmount = 500
                },
                new Book
                {
                    Id = 3,
                    IsOriginal = false,
                    PageAmount = 450
                }
            };
        }
    }
}
