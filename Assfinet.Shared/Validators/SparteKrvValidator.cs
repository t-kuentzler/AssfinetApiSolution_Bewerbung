using Assfinet.Shared.Entities;
using FluentValidation;

namespace Assfinet.Shared.Validators;

public class SparteKrvValidator : AbstractValidator<KrvSparte>
{
    public SparteKrvValidator()
    {
        RuleFor(v => v.AmsId).NotEmpty();
        RuleFor(v => v.Amsidnr)
            .NotEmpty()
            .MaximumLength(40);
        RuleFor(v => v.Key)
            .NotEmpty()
            .MaximumLength(40);
        RuleFor(v => v.Typ)
            .NotEmpty()
            .MaximumLength(50);
        RuleFor(v => v.License).MaximumLength(40);
        RuleFor(v => v.LastSynchronisation).NotNull();

    }
}