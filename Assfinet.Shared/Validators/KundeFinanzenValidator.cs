using FluentValidation;
using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Validators
{
    public class KundeFinanzenValidator : AbstractValidator<KundeFinanzen>
    {
        public KundeFinanzenValidator()
        {
            RuleFor(k => k.Einkommen).GreaterThanOrEqualTo(0).When(k => k.Einkommen.HasValue);
            RuleFor(k => k.GesetzlicheAltersrenteMonatlich).GreaterThanOrEqualTo(0).When(k => k.GesetzlicheAltersrenteMonatlich.HasValue);
            RuleFor(k => k.GesetzlicheBURenteMonatlich).GreaterThanOrEqualTo(0).When(k => k.GesetzlicheBURenteMonatlich.HasValue);
            RuleFor(k => k.GesetzlicheHinterbliebenenRenteMonatlich).GreaterThanOrEqualTo(0).When(k => k.GesetzlicheHinterbliebenenRenteMonatlich.HasValue);
            RuleFor(k => k.GesetzlicheHinterbliebenenRenteTeil).GreaterThanOrEqualTo(0).When(k => k.GesetzlicheHinterbliebenenRenteTeil.HasValue);
            RuleFor(k => k.ErwerbsminderungsrenteTeil).GreaterThanOrEqualTo(0).When(k => k.ErwerbsminderungsrenteTeil.HasValue);
            RuleFor(k => k.ErwerbsminderungsrenteVoll).GreaterThanOrEqualTo(0).When(k => k.ErwerbsminderungsrenteVoll.HasValue);
            RuleFor(k => k.GesetzlicheAltersrenteTeil).GreaterThanOrEqualTo(0).When(k => k.GesetzlicheAltersrenteTeil.HasValue);
            RuleFor(k => k.NichtSelbstaendigeArbeitBruttoMonatlich).GreaterThanOrEqualTo(0).When(k => k.NichtSelbstaendigeArbeitBruttoMonatlich.HasValue);
            RuleFor(k => k.NichtSelbstaendigeArbeitNettoMonatlich).GreaterThanOrEqualTo(0).When(k => k.NichtSelbstaendigeArbeitNettoMonatlich.HasValue);
            RuleFor(k => k.SelbstaendigeArbeitNettoMonatlich).GreaterThanOrEqualTo(0).When(k => k.SelbstaendigeArbeitNettoMonatlich.HasValue);
            RuleFor(k => k.SonstigeAlterseinkuenfteMonatlich).GreaterThanOrEqualTo(0).When(k => k.SonstigeAlterseinkuenfteMonatlich.HasValue);
            RuleFor(k => k.SonstigeEinkuenfteNettoMonatlich).GreaterThanOrEqualTo(0).When(k => k.SonstigeEinkuenfteNettoMonatlich.HasValue);
            RuleFor(k => k.SonstigeLaufendeKostenMonatlich).GreaterThanOrEqualTo(0).When(k => k.SonstigeLaufendeKostenMonatlich.HasValue);
            RuleFor(k => k.UnterhaltszahlungenMonatlich).GreaterThanOrEqualTo(0).When(k => k.UnterhaltszahlungenMonatlich.HasValue);
            RuleFor(k => k.GesetzlicheKrankenversichert).GreaterThanOrEqualTo(0).When(k => k.GesetzlicheKrankenversichert.HasValue);
            RuleFor(k => k.GesetzlichRentenversichert).GreaterThanOrEqualTo(0).When(k => k.GesetzlichRentenversichert.HasValue);
            RuleFor(k => k.GesetzlicheAltersrenteMonatlichAbzug).GreaterThanOrEqualTo(0).When(k => k.GesetzlicheAltersrenteMonatlichAbzug.HasValue);
            RuleFor(k => k.Inflationsrate).InclusiveBetween(0, 100).When(k => k.Inflationsrate.HasValue);
            RuleFor(k => k.Kapitalmarktzins).GreaterThanOrEqualTo(0).When(k => k.Kapitalmarktzins.HasValue);
            RuleFor(k => k.GAgZuschuss).GreaterThanOrEqualTo(0).When(k => k.GAgZuschuss.HasValue);
            RuleFor(k => k.GAgZuschussProz).InclusiveBetween(0, 100).When(k => k.GAgZuschussProz.HasValue);
            RuleFor(k => k.GesetzlicheAltersrenteNettobetrag).GreaterThanOrEqualTo(0).When(k => k.GesetzlicheAltersrenteNettobetrag.HasValue);
            RuleFor(k => k.GesetzlicheAltersrenteNetto).GreaterThanOrEqualTo(0).When(k => k.GesetzlicheAltersrenteNetto.HasValue);
            RuleFor(k => k.GesetzlicheAltersrenteJahresbetrag).GreaterThanOrEqualTo(0).When(k => k.GesetzlicheAltersrenteJahresbetrag.HasValue);
            RuleFor(k => k.GesetzlicheAltersrenteProz).InclusiveBetween(0, 100).When(k => k.GesetzlicheAltersrenteProz.HasValue);
            RuleFor(k => k.GesetzlicheHinterbliebenenRenteNettobetrag).GreaterThanOrEqualTo(0).When(k => k.GesetzlicheHinterbliebenenRenteNettobetrag.HasValue);
            RuleFor(k => k.GesetzlicheHinterbliebenenRenteNetto).GreaterThanOrEqualTo(0).When(k => k.GesetzlicheHinterbliebenenRenteNetto.HasValue);
            RuleFor(k => k.GesetzlicheHinterbliebenenRenteJahresbetrag).GreaterThanOrEqualTo(0).When(k => k.GesetzlicheHinterbliebenenRenteJahresbetrag.HasValue);
            RuleFor(k => k.GesetzlicheHinterbliebenenRenteProz).InclusiveBetween(0, 100).When(k => k.GesetzlicheHinterbliebenenRenteProz.HasValue);
            RuleFor(k => k.GesetzlicheHinterbliebenenRenteNettoAbzug).GreaterThanOrEqualTo(0).When(k => k.GesetzlicheHinterbliebenenRenteNettoAbzug.HasValue);
            RuleFor(k => k.GesetzlicheHinterbliebenenRenteNettoZuschuss).GreaterThanOrEqualTo(0).When(k => k.GesetzlicheHinterbliebenenRenteNettoZuschuss.HasValue);
            RuleFor(k => k.GesetzlicheHinterbliebenenRenteNettoZuschussProz).InclusiveBetween(0, 100).When(k => k.GesetzlicheHinterbliebenenRenteNettoZuschussProz.HasValue);
            RuleFor(k => k.Kundeninkassokonto).GreaterThanOrEqualTo(0).When(k => k.Kundeninkassokonto.HasValue);
            RuleFor(k => k.SubunternehmerAuftragswert).GreaterThanOrEqualTo(0).When(k => k.SubunternehmerAuftragswert.HasValue);
            RuleFor(k => k.SummeEigeneBauvorhaben).GreaterThanOrEqualTo(0).When(k => k.SummeEigeneBauvorhaben.HasValue);
            RuleFor(k => k.WarenMaterialwertProJahr).GreaterThanOrEqualTo(0).When(k => k.WarenMaterialwertProJahr.HasValue);
        }
    }
}
