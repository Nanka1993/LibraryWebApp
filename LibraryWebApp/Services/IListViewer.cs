using LibraryWebApp.Dto;
using System;
using System.Collections.Generic;

namespace LibraryWebApp.Services
{
    public interface IListViewer<out TView, TFilter> : IDisposable
    {
        IEnumerable<TView> GetItems(FilterWithPaginationAndSorting<TFilter> filterWithPaginationAndSorting);
    }
}