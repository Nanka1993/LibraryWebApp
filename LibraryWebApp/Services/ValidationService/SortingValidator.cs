using FluentValidation;
using LibraryWebApp.Dto;

namespace LibraryWebApp.Services.ValidationService
{
    public class SortingValidator : AbstractValidator<SortingField>
    {
        public SortingValidator()
        {
            RuleFor(x => x.Name)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .When(x => x != null)
                .WithMessage("Укажите поле сортировки");
        }
    }
}