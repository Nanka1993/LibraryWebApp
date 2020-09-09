using LibraryWebApp.Models.Domain;
using System.Collections.Generic;

namespace LibraryWebApp.Services.FilteringServices
{
    /// <summary>
    /// Сервис фильтрации для публикаций
    /// </summary>
    public interface IFilteringService<out TResult, in TFilter>
        where TResult : AbstractPublication
    {
        /// <summary>
        /// Возвращает отфильтрованный результат
        /// </summary>
        IEnumerable<TResult> GetPublications(TFilter filter);

    }
}
