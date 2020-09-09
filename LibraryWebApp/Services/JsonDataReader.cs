using LibraryWebApp.Extensions;
using LibraryWebApp.Models.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace LibraryWebApp.Services
{
    public class JsonDataReader
    {
        public IEnumerable<T> GetJsonData<T>(string fileName)
        {
            var filePathName = "JsonData".GetDataPath(fileName);

            var json = File.ReadAllText(filePathName);
            return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
        }
    }
}
