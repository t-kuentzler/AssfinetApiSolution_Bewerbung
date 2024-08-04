using Assfinet.Shared.Entities;
using FluentValidation;

namespace Assfinet.Shared.Validators;

public class DepSparteValidator : AbstractValidator<DepSparte>
{
    public DepSparteValidator()
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
        RuleFor(v => v.LastSynchronisation).NotEmpty();

        RuleFor(v => v.DEP101).MaximumLength(150);
        RuleFor(v => v.DEP111).MaximumLength(150);
        RuleFor(v => v.DEP113).MaximumLength(150);
        RuleFor(v => v.DEP115).MaximumLength(150);
        RuleFor(v => v.DEP116).MaximumLength(150);
        RuleFor(v => v.DEP119).MaximumLength(150);
        RuleFor(v => v.DEP120).MaximumLength(150);
        RuleFor(v => v.DEP122).MaximumLength(150);
        RuleFor(v => v.DEP125).MaximumLength(150);
        RuleFor(v => v.DEP126).MaximumLength(150);
        RuleFor(v => v.DEP128).MaximumLength(150);
        RuleFor(v => v.DEP131).MaximumLength(150);
        RuleFor(v => v.DEP132).MaximumLength(150);
        RuleFor(v => v.DEP134).MaximumLength(150);
        RuleFor(v => v.DEP137).MaximumLength(150);
        RuleFor(v => v.DEP138).MaximumLength(150);
        RuleFor(v => v.DEP140).MaximumLength(150);
        RuleFor(v => v.DEP143).MaximumLength(150);
        RuleFor(v => v.DEP144).MaximumLength(150);
        RuleFor(v => v.DEP146).MaximumLength(150);
        RuleFor(v => v.DEP149).MaximumLength(150);
        RuleFor(v => v.DEP150).MaximumLength(150);
        RuleFor(v => v.DEP152).MaximumLength(150);
        RuleFor(v => v.DEP155).MaximumLength(150);
        RuleFor(v => v.DEP156).MaximumLength(150);
        RuleFor(v => v.DEP158).MaximumLength(150);
        RuleFor(v => v.DEP161).MaximumLength(150);
        RuleFor(v => v.DEP162).MaximumLength(150);
        RuleFor(v => v.DEP164).MaximumLength(150);
        RuleFor(v => v.DEP167).MaximumLength(150);
        RuleFor(v => v.DEP168).MaximumLength(150);
        RuleFor(v => v.DEP170).MaximumLength(150);
        RuleFor(v => v.DEP173).MaximumLength(150);
        RuleFor(v => v.DEP174).MaximumLength(150);
        RuleFor(v => v.DEP176).MaximumLength(150);
        RuleFor(v => v.DEP178).MaximumLength(150);
        RuleFor(v => v.DEP179).MaximumLength(150);
        RuleFor(v => v.DEP180).MaximumLength(150);
    }
}