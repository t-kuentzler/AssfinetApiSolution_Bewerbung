using System.ComponentModel.DataAnnotations;

namespace Assfinet.Shared.Entities
{
    public class KundePersonenDetails
    {
        public int KundeId { get; set; }
        [StringLength(70)] public string? Anrede { get; set; }
        [StringLength(15)] public string? Arbeitgeber { get; set; }
        public decimal? AusbildungskostenMonatlich { get; set; }
        public DateTime? AustrittsdatumArbeitgeber { get; set; }
        [StringLength(60)] public string? Beruf { get; set; }
        [StringLength(40)] public string? Berufsstatus { get; set; }
        [StringLength(50)] public string? Besitzverhaeltnis { get; set; }
        [StringLength(10)] public string? Bilanzstichtag { get; set; }
        [StringLength(60)] public string? Branche { get; set; }
        public decimal? Bruttojahresmietwert { get; set; }
        public decimal? Bruttojahresumsatz { get; set; }
        [StringLength(25)] public string? Bundesland { get; set; }
        [StringLength(30)] public string? Familienstand { get; set; }
        [StringLength(200)] public string? Geburtsname { get; set; }
        [StringLength(32)] public string? Geburtsort { get; set; }
        public DateTime? Geburtstag { get; set; }
        [StringLength(10)] public string? Geschlecht { get; set; }
        [StringLength(50)] public string? GVersicherer1 { get; set; }
        [StringLength(50)] public string? GVersicherer2 { get; set; }
        [StringLength(50)] public string? GVersicherer3 { get; set; }
        [StringLength(50)] public string? GVersicherer4 { get; set; }
        [StringLength(50)] public string? GVersicherer5 { get; set; }
        [StringLength(100)] public string? Handelsregisternummer { get; set; }
        public bool? Hinterbliebenenrente { get; set; }
        [StringLength(40)] public string? HistorieZuKunde { get; set; }
        public bool? Honorarkunde { get; set; }
        public DateTime? IdentDate { get; set; }
        public DateTime? IdentGueltigBis { get; set; }
        [StringLength(30)] public string? IdentTyp { get; set; }
        public decimal? Inflationsrate { get; set; }
        [StringLength(20)] public string? Info_01 { get; set; }
        [StringLength(30)] public string? Informationsweg { get; set; }
        [StringLength(100)] public string? InhaberGF { get; set; }
        [StringLength(15)] public string? InterneNr { get; set; }
        public bool? IsHistorie { get; set; }
        [StringLength(3)] public string? IsoLand { get; set; }
        public bool? IsZukunft { get; set; }
        [StringLength(40)] public string? KeyIdentDate { get; set; }
        public int? Kinder { get; set; }
        [StringLength(20)] public string? Kindergeldnummer { get; set; }
        public decimal? KinderLautSteuerkarte { get; set; }
        public bool? Kirchensteuer { get; set; }
        [StringLength(5)] public string? Klasse { get; set; }
        [StringLength(12)] public string? Sozialversicherungsnummer { get; set; }
        [StringLength(3)] public string? Staatsangehoerigkeit { get; set; }
        [StringLength(15)] public string? Status { get; set; }
        [StringLength(15)] public string? SteuerIdentifikationsnummer { get; set; }
        [StringLength(10)] public string? Steuerklasse { get; set; }
        [StringLength(20)] public string? Steuernummer { get; set; }
        public DateTime? Verstorben { get; set; }
        [StringLength(40)] public string? Vorname { get; set; }
        public bool? Wasserschutzgebiet { get; set; }
        public string? Zuordnung { get; set; }

        // Navigation properties
        public virtual Kunde Kunde { get; set; }
    }
}
