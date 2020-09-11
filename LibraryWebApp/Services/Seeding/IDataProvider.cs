using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Services.Seeding
{
    public interface IDataProvider
    {
        IEnumerable<T> GetData<T>();
    }
}
