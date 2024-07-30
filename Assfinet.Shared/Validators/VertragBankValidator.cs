using FluentValidation;
using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Validators
{
    public class VertragBankValidator : AbstractValidator<VertragBank>
    {
        public VertragBankValidator()
        {
            RuleFor(vb => vb.Bic).MaximumLength(11);
            RuleFor(vb => vb.Blz).MaximumLength(8);
            RuleFor(vb => vb.Iban).MaximumLength(34);
            RuleFor(vb => vb.Konto).MaximumLength(12);
            RuleFor(vb => vb.Kontobezeichnung).MaximumLength(50);
        }
    }
}