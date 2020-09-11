using LibraryWebApp.Extensions;
using LibraryWebApp.Models.Domain;
using LibraryWebApp.Services.Seeding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryWebApp.Services
{
    public class JsonDataProvider : IDataProvider
    {
        public IEnumerable<T> GetData<T>()
        {
            var fileName = string.Empty;
            if (typeof(T) == typeof(Article))
            {
                fileName = "Articles.json";
            }
            if (typeof(T) == typeof(Book))
            {
                fileName = "Books.json";
            }
            if (typeof(T) == typeof(Dissertation))
            {
                fileName = "Dissertations.json";
            }
            if (typeof(T) == typeof(Magazine))
            {
                fileName = "Magazines.json";
            }
            if (typeof(T) == typeof(SynopsisOfThesis))
            {
                fileName = "SynopsisOfThesis.json";
            }
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentOutOfRangeException(typeof(T).Name);
            }
            return GetData<T>(fileName);
        }

        private IEnumerable<T> GetData<T>(string fileName)
        {
            var filePathName = @"LibraryWebApp\JsonData".GetDataPath(fileName);

            var json = File.ReadAllText(filePathName);
            return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
        }
    }
}
