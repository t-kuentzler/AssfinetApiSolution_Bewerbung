using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assfinet.Shared.Entities
{
    public class Kunde
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string Adrid { get; set; }
        [StringLength(100)]
        public string Aenderungsgrund { get; set; }
        public DateTime? Aenderung { get; set; }
        [NotMapped]
        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
        [StringLength(40)]
        public string Amsidnr { get; set; }
        public Guid AmsId { get; set; }
        [StringLength(40)]
        public string Bearbeiter { get; set; }
        public DateTime? Bearbeitet { get; set; }
        [StringLength(200)]
        public string BelegteSparten { get; set; }
        [StringLength(11)]
        public string Debitor { get; set; }
        public bool Dirty { get; set; }
        public DateTime? DsgvoDeleteDate { get; set; }
        public DateTime? DsgvoLockDate { get; set; }
        public bool? DsgvoLocked { get; set; }
        public bool? Duzen { get; set; }
        [StringLength(20)]
        public string DtazvEntgelt { get; set; }
        [StringLength(40)]
        public string EloGid { get; set; }
        public DateTime? EintrittsdatumArbeitgeber { get; set; }
        public int? Erloeskonto { get; set; }
        public DateTime? ErlUwg7 { get; set; }
        public bool? GesetzlicheAltersrenteMonatlichAbzug { get; set; }
        public decimal? GesetzlicheAltersrenteMonatlich { get; set; }
        public decimal? GesetzlicheAltersrenteNetto { get; set; }
        public decimal? GesetzlicheAltersrenteNettobetrag { get; set; }
        public decimal? GesetzlicheAltersrenteProz { get; set; }
        public decimal? GesetzlicheAltersrenteTeil { get; set; }
        public decimal? GesetzlicheBURenteMonatlich { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteJahresbetrag { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteMonatlich { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteNetto { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteNettoAbzug { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteNettoZuschuss { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteNettoZuschussProz { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteNettobetrag { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteProz { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteTeil { get; set; }
        public bool? GesetzlichKrankenversichert { get; set; }
        public bool? GesetzlichRentenversichert { get; set; }
        public DateTime? GewuenschterRentenbeginn { get; set; }
        [StringLength(50)]
        public string GTarif1 { get; set; }
        [StringLength(50)]
        public string GTarif2 { get; set; }
        [StringLength(50)]
        public string GTarif3 { get; set; }
        [StringLength(50)]
        public string GTarif4 { get; set; }
        [StringLength(50)]
        public string GTarif5 { get; set; }
        public DateTime? GueltigAb { get; set; }
        public DateTime? GueltigBis { get; set; }
        [StringLength(10)]
        public string GVstAbzug { get; set; }
        public decimal? GVstAnteil { get; set; }
        public DateTime? GVstSeit { get; set; }
        public bool? GVtAccount { get; set; }
        public bool? GZuschussAltVt { get; set; }
        [StringLength(100)]
        public string Handelsregisternummer { get; set; }
        public DateTime? IdentDate { get; set; }
        public DateTime? IdentGueltigBis { get; set; }
        [StringLength(30)]
        public string IdentTyp { get; set; }
        public decimal? Inflationsrate { get; set; }
        public string License { get; set; }
        public DateTime LastSynchronisation { get; private set; }
        [StringLength(50)]
        public string LageBetriebsgrundstuecks { get; set; }
        [StringLength(3)]
        public string Land { get; set; }
        [StringLength(50)]
        public string Landesname { get; set; }
        public DateTime? LetzterBesuch { get; set; }
        public decimal? LohnGehaltssumme { get; set; }
        [StringLength(50)]
        public string Mandant { get; set; }
        [StringLength(40)]
        public string MandantAmsidnr { get; set; }
        public DateTime? MahnstopBis { get; set; }
        public DateTime? MaklervertragBis { get; set; }
        public DateTime? MaklervertragDatum { get; set; }
        public decimal? MieteNebenkostenMonatlich { get; set; }
        public decimal? Mietsteigerung { get; set; }
        public int? Mitarbeiterzahl { get; set; }
        [StringLength(35)]
        public string Mobiltelefon { get; set; }
        [StringLength(40)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Name1 { get; set; }
        [StringLength(200)]
        public string Name2 { get; set; }
        [StringLength(200)]
        public string Name3 { get; set; }
        public decimal? NichtSelbstaendigeArbeitBruttoMonatlich { get; set; }
        public decimal? NichtSelbstaendigeArbeitNettoMonatlich { get; set; }
        [StringLength(50)]
        public string Ort { get; set; }
        [StringLength(50)]
        public string OrtPhonetisch { get; set; }
        [StringLength(30)]
        public string PAusbildung { get; set; }
        public DateTime? PAustrittVorag { get; set; }
        public bool? PBefristvt { get; set; }
        [StringLength(20)]
        public string PBeschaeftignungsverhaeltnis { get; set; }
        [StringLength(100)]
        public string PBildung { get; set; }
        public DateTime? PBefristvtBis { get; set; }
        public bool? Pep { get; set; }
        public DateTime? PersonalausweisAusstellungsdatum { get; set; }
        [StringLength(30)]
        public string PersonalausweisBehoerde { get; set; }
        public DateTime? PersonalausweisGueltigBis { get; set; }
        [StringLength(30)]
        public string PersonalausweisNr { get; set; }
        [StringLength(20)]
        public string Personalnummer { get; set; }
        [StringLength(30)]
        public string PFsbehoerde { get; set; }
        public DateTime? PFsdatum { get; set; }
        public DateTime? PFsgueltigab { get; set; }
        [StringLength(20)]
        public string PFsnummer { get; set; }
        public bool? PProbezeit { get; set; }
        public DateTime? PProbezeitbis { get; set; }
        public DateTime? PraemienrechnungAb { get; set; }
        public DateTime? PraemienrechnungBis { get; set; }
        public decimal? PRiester { get; set; }
        public int? Provision { get; set; }
        public decimal? PRuerup { get; set; }
        public decimal? PVorsorge { get; set; }
        public decimal? PVwl { get; set; }
        public bool? PVwlGenutzt { get; set; }
        public decimal? PWochenarbeitszeit { get; set; }
        public string Rechtsform { get; set; }
        public bool? Rechexcel { get; set; }
        public bool? RechnungsMail { get; set; }
        [StringLength(100)]
        public string Repraesentant { get; set; }
        [StringLength(500)]
        public string S21_F1 { get; set; }
        [StringLength(500)]
        public string S21_F10 { get; set; }
        [StringLength(500)]
        public string S21_F2 { get; set; }
        [StringLength(500)]
        public string S21_F3 { get; set; }
        [StringLength(500)]
        public string S21_F4 { get; set; }
        [StringLength(500)]
        public string S21_F5 { get; set; }
        [StringLength(500)]
        public string S21_F6 { get; set; }
        [StringLength(500)]
        public string S21_F7 { get; set; }
        [StringLength(500)]
        public string S21_F8 { get; set; }
        [StringLength(500)]
        public string S21_F9 { get; set; }
        [StringLength(500)]
        public string S22_F1 { get; set; }
        [StringLength(500)]
        public string S22_F10 { get; set; }
        [StringLength(500)]
        public string S22_F2 { get; set; }
        [StringLength(500)]
        public string S22_F3 { get; set; }
        [StringLength(500)]
        public string S22_F4 { get; set; }
        [StringLength(500)]
        public string S22_F5 { get; set; }
        [StringLength(500)]
        public string S22_F6 { get; set; }
        [StringLength(500)]
        public string S22_F7 { get; set; }
        [StringLength(500)]
        public string S22_F8 { get; set; }
        [StringLength(500)]
        public string S22_F9 { get; set; }
        [StringLength(40)]
        public string Sachbearbeiter { get; set; }
        [StringLength(250)]
        public string Schlagwoerter { get; set; }
        public DateTime? Sepamandat { get; set; }
        [StringLength(35)]
        public string Sepamandatsreferenz { get; set; }
        [StringLength(30)]
        public string SepaSddType { get; set; }
        public decimal? SelbstaendigeArbeitNettoMonatlich { get; set; }
        public DateTime? StichtagBruttojahresmietwert { get; set; }
        public DateTime? StichtagBruttojahresumsatz { get; set; }
        public DateTime? StichtagLohnGehaltssumme { get; set; }
        public DateTime? StichtagSubunternehmerAuftragswert { get; set; }
        public DateTime? StichtagSummeEigeneBauvorhaben { get; set; }
        public DateTime? StichtagWarenMaterialwertProJahr { get; set; }
        public DateTime? StopAbrechnungBis { get; set; }
        public DateTime? StopZahlungBis { get; set; }
        [StringLength(50)]
        public string Strasse { get; set; }
        [StringLength(50)]
        public string StrassePhonetisch { get; set; }
        public DateTime? TaetigAufBetriebsgrundstueckSeit { get; set; }
        [StringLength(20)]
        public string Titel { get; set; }
        public bool? Trockenbett { get; set; }
        public bool? Ueberschwemmungsgebiet { get; set; }
        public bool? Umfriedet { get; set; }
        public int? Umsatz { get; set; }
        [StringLength(4)]
        public string UmsatzJahr { get; set; }
        [StringLength(20)]
        public string USTIDNr { get; set; }
        public DateTime? Verstorben { get; set; }
        [StringLength(50)]
        public string Vm1 { get; set; }
        [StringLength(50)]
        public string Vm10 { get; set; }
        [StringLength(50)]
        public string Vm2 { get; set; }
        [StringLength(50)]
        public string Vm3 { get; set; }
        [StringLength(50)]
        public string Vm4 { get; set; }
        [StringLength(50)]
        public string Vm5 { get; set; }
        [StringLength(50)]
        public string Vm6 { get; set; }
        [StringLength(50)]
        public string Vm7 { get; set; }
        [StringLength(50)]
        public string Vm8 { get; set; }
        [StringLength(50)]
        public string Vm9 { get; set; }
        [StringLength(40)]
        public string VnMvertrag { get; set; }
        [StringLength(15)]
        public string Vnnummer { get; set; }
        public int? VnSepaPreNotificationtAge { get; set; }
        public decimal? WarenMaterialwertProJahr { get; set; }
        public bool? Wasserschutzgebiet { get; set; }
        [StringLength(3)]
        public string Zuordnung { get; set; }

        // Navigation properties
        public virtual KundePersonenDetails PersonenDetails { get; set; }
        public virtual KundeFinanzen Finanzen { get; set; }
        public virtual KundeKontakt Kontakt { get; set; }
        public virtual ICollection<Vertrag> Vertraege { get; set; }
    }
}
