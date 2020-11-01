using FluentValidation;
using LibraryWebApp.Dto;
using LibraryWebApp.Dto.Filters;
using LibraryWebApp.Services.ValidationService;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryWebApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<BookFilter>, BookFilterValidator>();
            services.AddScoped<IValidator<SortingField>, SortingValidator>();
            services.AddScoped<IValidator<Pagination>, PaginationValidator>();
            services.AddScoped<IValidator<FilterSortPaging<BookFilter>>, BookFilterSortPagingValidator>();
        }
    }
}
