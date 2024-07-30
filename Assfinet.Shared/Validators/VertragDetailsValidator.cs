using FluentValidation;
using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Validators
{
    public class VertragDetailsValidator : AbstractValidator<VertragDetails>
    {
        public VertragDetailsValidator()
        {
            RuleFor(vd => vd.AbrInfo).MaximumLength(150);
            RuleFor(vd => vd.Abschlussvermittler).MaximumLength(50);
            RuleFor(vd => vd.AendGrund).MaximumLength(100);
            RuleFor(vd => vd.Anfrage).NotNull();
            RuleFor(vd => vd.Angebot).NotNull();
            RuleFor(vd => vd.AnpassungAm).NotNull();
            RuleFor(vd => vd.Antrag).NotNull();
            RuleFor(vd => vd.AnzahlZahlungenProJahr).GreaterThan(0);
            RuleFor(vd => vd.Anzcourtzahlung).GreaterThan(0);
            RuleFor(vd => vd.ApInfo).MaximumLength(10);
            RuleFor(vd => vd.Art).MaximumLength(10);
            RuleFor(vd => vd.Berater).MaximumLength(30);
            RuleFor(vd => vd.BeratungErforderlich).NotNull();
            RuleFor(vd => vd.Beratungsgebiet).MaximumLength(50);
            RuleFor(vd => vd.Beschreibung).MaximumLength(150);
            RuleFor(vd => vd.Bestaetigung).NotNull();
            RuleFor(vd => vd.Beteiligungsverhaeltnis).NotNull();
            RuleFor(vd => vd.BetreuungsvertragsNr).MaximumLength(40);
            RuleFor(vd => vd.Status).MaximumLength(9);
            RuleFor(vd => vd.Sachbearbeiter).MaximumLength(40);
            RuleFor(vd => vd.Sammelvertrag).NotNull();
        }
    }
}