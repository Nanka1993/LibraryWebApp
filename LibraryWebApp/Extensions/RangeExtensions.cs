using LibraryWebApp.Constants;
using LibraryWebApp.Dto;
using LibraryWebApp.Models.Domain;
using System.Linq;

namespace LibraryWebApp.Extensions
{
    public static class RangeExtensions
    {
        public static IQueryable<T> AddYearRangeFilter<T>(this IQueryable<T> query, IntRange range)
            where T : AbstractPublication
        {
            if (range == null)
            {
                return query;
            }

            return query.Where(x => x.Year >= (range.Gte ?? FilterLimits.MinYear)
            && x.Year <= (range.Lte ?? FilterLimits.MaxYear));
        }

        public static IQueryable<T> AddPageRangeFilter<T>(this IQueryable<T> query, IntRange range)
            where T : AbstractPublication
        {
            if (range == null)
            {
                return query;
            }

            return query.Where(x => x.PageAmount >= (range.Gte ?? FilterLimits.MinPageNumber)
            && x.PageAmount <= (range.Lte ?? FilterLimits.MaxPageNumber));
        }
    }
}
