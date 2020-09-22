using System;

namespace LibraryWebApp.Services
{
    public interface  IWriter<T> : IDisposable
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }

}
