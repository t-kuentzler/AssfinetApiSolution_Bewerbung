
namespace Assfinet.Shared.Entities
{
    public class KundeFinanzen
    {
        public int KundeId { get; set; }
        public decimal? Einkommen { get; set; }
        public decimal? GesetzlicheAltersrenteMonatlich { get; set; }
        public decimal? GesetzlicheBURenteMonatlich { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteMonatlich { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteTeil { get; set; }
        public decimal? ErwerbsminderungsrenteTeil { get; set; }
        public decimal? ErwerbsminderungsrenteVoll { get; set; }
        public decimal? GesetzlicheAltersrenteTeil { get; set; }
        public decimal? NichtSelbstaendigeArbeitBruttoMonatlich { get; set; }
        public decimal? NichtSelbstaendigeArbeitNettoMonatlich { get; set; }
        public decimal? SelbstaendigeArbeitNettoMonatlich { get; set; }
        public decimal? SonstigeAlterseinkuenfteMonatlich { get; set; }
        public decimal? SonstigeEinkuenfteNettoMonatlich { get; set; }
        public decimal? SonstigeLaufendeKostenMonatlich { get; set; }
        public decimal? UnterhaltszahlungenMonatlich { get; set; }
        public decimal? GesetzlicheKrankenversichert { get; set; }
        public decimal? GesetzlichRentenversichert { get; set; }
        public decimal? GesetzlicheAltersrenteMonatlichAbzug { get; set; }
        public decimal? Inflationsrate { get; set; }
        public decimal? Kapitalmarktzins { get; set; }
        public decimal? GAgZuschuss { get; set; }
        public decimal? GAgZuschussProz { get; set; }
        public decimal? GesetzlicheAltersrenteNettobetrag { get; set; }
        public decimal? GesetzlicheAltersrenteNetto { get; set; }
        public decimal? GesetzlicheAltersrenteJahresbetrag { get; set; }
        public decimal? GesetzlicheAltersrenteProz { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteNettobetrag { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteNetto { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteJahresbetrag { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteProz { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteNettoAbzug { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteNettoZuschuss { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteNettoZuschussProz { get; set; }
        public decimal? Kundeninkassokonto { get; set; }
        public decimal? SubunternehmerAuftragswert { get; set; }
        public decimal? SummeEigeneBauvorhaben { get; set; }
        public decimal? WarenMaterialwertProJahr { get; set; }

        // Navigation properties
        public virtual Kunde Kunde { get; set; }
    }
}
