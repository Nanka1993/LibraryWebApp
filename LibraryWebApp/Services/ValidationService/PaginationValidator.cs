﻿using FluentValidation;
using LibraryWebApp.Dto;

namespace LibraryWebApp.Services.ValidationService
{
    public class PaginationValidator : AbstractValidator<Pagination>
    {
        public PaginationValidator()
        {
            RuleFor(x => x.Skip)
                .Must(x => x  >= 0)
                .When(x => x.Skip.HasValue);
            RuleFor(x => x.Take)
                .Must(x => x > 0)
                .When(x => x.Take.HasValue);
        }
    }
}