using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Services
{
    public interface  IWriter<T> : IDisposable
    {
        void Create(T entity);
    }

}
