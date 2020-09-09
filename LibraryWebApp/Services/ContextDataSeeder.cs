using LibraryWebApp.Database;
using LibraryWebApp.Models.Domain;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWebApp.Services
{
    public class ContextDataSeeder
    {
            private readonly LibraryContext _context;

            /// <summary>
            /// Конструктор по умолчанию
            /// </summary>
            /// <param name="context">Контекст БД</param>
            public ContextDataSeeder(LibraryContext context)
            {
                _context = context;
            }

            /// <inheritdoc/>>
            public string Seed()
            {
                AddJsonDataToContext<Dissertation>("Dissertations.json");
                AddJsonDataToContext<Magazine>("Magazines.json");
                AddJsonDataToContext<Article>("Articles.json");
                AddJsonDataToContext<SynopsisOfThesis>("SynopsisOfThesis.json");
                AddJsonDataToContext<Book>("Books.json");

                _context.SaveChanges();

                return "Данные успешно сохранены";
            }

            private void AddJsonDataToContext<T>(string fileName)
                where T : class
            {
                var enumerable = _context.Set<T>()
                    .AsEnumerable();
                var jsonReader = new JsonDataReader();
                var freshData = jsonReader.GetJsonData<T>(fileName)
                    .Where(x => !PublicationExists(enumerable, x))
                    .ToArray();

                if (freshData.Any())
                {
                    _context.Set<T>().AddRange(freshData);
                }
            }

            //private static IEnumerable<T> GetJsonData<T>(string fileName)
            //{
            //    var filePathName = "JsonData".GetDataPath(fileName);

            //    var json = File.ReadAllText(filePathName);
            //    return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            //}

            private static bool PublicationExists<T>(IEnumerable<T> entities, T entity)
                where T : class
            {
                if (entity == null)
                {
                    return false;
                }

                return entities.FirstOrDefault(x => x.Equals(entity)) != null;
            }
        }
}
