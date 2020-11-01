using FluentValidation;
using LibraryWebApp.Constants;
using LibraryWebApp.Dto.Filters;

namespace LibraryWebApp.Services.ValidationService
{
    public class BookFilterValidator : AbstractValidator<BookFilter>
    {
        public BookFilterValidator()
        {
            RuleFor(x => x.PageRange)
                .Must(x => (x.Gte ?? FilterLimits.MinPageNumber) > 0)
                .When(x => x.PageRange != null)
                .WithMessage("Нижняя граница диапазона должна быть больше 0");

            RuleFor(x => x.PageRange)
                .Must(x => (x.Lte ?? FilterLimits.MaxPageNumber) > 0)
                .Unless(x => x.PageRange == null)
                .WithMessage("Верхняя граница диапазона должна быть больше 0");

            RuleFor(x => x.PageRange)
                .Must(x => (x.Lte ?? FilterLimits.MaxPageNumber) > (x.Gte ?? FilterLimits.MinPageNumber))
                .When(x => x.PageRange != null)
                .WithMessage("Нижняя граница диапазона не должна быть равна или выше верхней");
        }
    }
}