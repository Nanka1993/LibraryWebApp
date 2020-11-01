using FluentValidation;
using LibraryWebApp.Dto;
using LibraryWebApp.Dto.Filters;

namespace LibraryWebApp.Services.ValidationService
{
    public class BookFilterSortPagingValidator : AbstractValidator<FilterSortPaging<BookFilter>>
    {
        public BookFilterSortPagingValidator(IValidator<BookFilter> bookValidator, IValidator<SortingField> sortingValidator)
        {
            RuleFor(x => x.Filter)
                .SetValidator(bookValidator)
                .When(x => x.Filter != null);
            RuleForEach(x => x.SortingFields)
                .SetValidator(sortingValidator);
        }
    }
}