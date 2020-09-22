using System.Collections.Generic;

namespace LibraryWebApp.Services.Seeding
{
    public interface IDataProvider
    {
        IEnumerable<T> GetData<T>();
    }
}
