using FluentValidation;
using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Validators
{
    public class VertragValidator : AbstractValidator<Vertrag>
    {
        public VertragValidator()
        {
            RuleFor(v => v.AmsId).NotEmpty();
            RuleFor(v => v.Amsidnr)
                .NotEmpty()
                .MaximumLength(40);
            RuleFor(v => v.Sparte).MaximumLength(20);
            RuleFor(v => v.Details).MaximumLength(60);
            RuleFor(v => v.Key).NotEmpty().MaximumLength(40);
            RuleFor(v => v.Vu).MaximumLength(40);
            RuleFor(v => v.VuNummer).GreaterThan(0);
            RuleFor(v => v.ComputedStatus).MaximumLength(60);
            RuleFor(v => v.Dirty).NotNull();
            RuleFor(v => v.License).MaximumLength(40);
            RuleFor(v => v.LastSynchronisation).NotNull();

            RuleFor(v => v.Finanzen).SetValidator(new VertragFinanzenValidator());
            RuleFor(v => v.VertragDetails).SetValidator(new VertragDetailsValidator());
            RuleFor(v => v.Historie).SetValidator(new VertragHistorieValidator());
            RuleFor(v => v.BankDetails).SetValidator(new VertragBankValidator());
        }
    }
}