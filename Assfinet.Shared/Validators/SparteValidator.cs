using Assfinet.Shared.Entities;
using FluentValidation;

namespace Assfinet.Shared.Validators;

public class SparteValidator : AbstractValidator<Sparte>
{
    public SparteValidator()
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

        // Dynamische Validierung für SparteFields
        RuleForEach(v => v.SparteFields).ChildRules(fields =>
        {
            fields.RuleFor(f => f.FieldName).NotEmpty().MaximumLength(50);
            fields.RuleFor(f => f.FieldValue).MaximumLength(150);
        });
    }
}