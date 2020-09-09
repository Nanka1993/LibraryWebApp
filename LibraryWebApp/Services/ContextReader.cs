using LibraryWebApp.Database;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWebApp.Services
    {
    public class ContextReader<T> : IReader<T>
        where T : class
    {
        private readonly LibraryContext _context;

        public ContextReader(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetItems()
        {
            return _context.Set<T>()
                .AsEnumerable();
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>()
                .AsQueryable();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}