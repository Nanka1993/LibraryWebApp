using LibraryWebApp.Database;
using LibraryWebApp.Models.Domain;
using LibraryWebApp.Services.Seeding;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryWebApp.Services
{
    public class ContextDataSeeder : BackgroundService
    {
            private readonly LibraryContext _context;
            private readonly IDataProvider _provider;

            /// <summary>
            /// Конструктор по умолчанию
            /// </summary>
            /// <param name="context">Контекст БД</param>
            public ContextDataSeeder(LibraryContext context, IDataProvider provider)
            {
                _context = context;
                _provider = provider;
            }

            /// <inheritdoc/>>
            public string Seed()
            {
            AddJsonDataToContext<Dissertation>();
            AddJsonDataToContext<Magazine>();
            AddJsonDataToContext<Article>();
            AddJsonDataToContext<SynopsisOfThesis>();
            AddJsonDataToContext<Book>();

            _context.SaveChanges();

            return "Данные успешно сохранены";
            }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Seed();
            return Task.CompletedTask;
        }

        private void AddJsonDataToContext<T>()
                where T : IdName
            {
                var enumerable = _context.Set<T>()
                    .AsEnumerable();
            var freshData = _provider.GetData<T>()
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
