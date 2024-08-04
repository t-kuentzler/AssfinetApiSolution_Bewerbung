using FluentValidation;
using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Validators
{
    public class KundeKontaktValidator : AbstractValidator<KundeKontakt>
    {
        public KundeKontaktValidator()
        {
            RuleFor(k => k.Bank1)
                .MaximumLength(40);

            RuleFor(k => k.Bank2)
                .MaximumLength(40);

            RuleFor(k => k.Bic1)
                .MaximumLength(11);

            RuleFor(k => k.Bic2)
                .MaximumLength(11);

            RuleFor(k => k.Blz1)
                .MaximumLength(12);

            RuleFor(k => k.Blz2)
                .MaximumLength(12);

            RuleFor(k => k.EmailGeschaeftlich)
                .MaximumLength(80);

            RuleFor(k => k.EmailPrivat)
                .MaximumLength(80);

            RuleFor(k => k.Fax)
                .MaximumLength(35);

            RuleFor(k => k.Iban1)
                .MaximumLength(34);

            RuleFor(k => k.Iban2)
                .MaximumLength(34);

            RuleFor(k => k.Mobiltelefon)
                .MaximumLength(35);

            RuleFor(k => k.Konto1)
                .MaximumLength(12);

            RuleFor(k => k.Konto2)
                .MaximumLength(12);

            RuleFor(k => k.Kontobezeichnung1)
                .MaximumLength(100);

            RuleFor(k => k.Kontobezeichnung2)
                .MaximumLength(100);

            RuleFor(k => k.Kontoinhaber1)
                .MaximumLength(40);

            RuleFor(k => k.Kontoinhaber2)
                .MaximumLength(40);

            RuleFor(k => k.Internet)
                .MaximumLength(200);

            RuleFor(k => k.TelefonGeschaeftlich)
                .MaximumLength(35);

            RuleFor(k => k.TelefonPrivat)
                .MaximumLength(35);
        }
    }
}