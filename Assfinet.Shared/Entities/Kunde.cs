using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assfinet.Shared.Entities;

public class Kunde
    {
        public int Id { get; set; }
        public Guid AmsId { get; set; } 
        public DateTime? Bearbeitet { get; set; }
        public bool Dirty { get; set; } // Automatisches Feld, soll nicht manuell gesetzt werden
        public string License { get; set; }
        public DateTime LastSynchronisation { get; private set; }
        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
        
        [StringLength(40)]
        public string Adrid { get; set; } // StringLength = 40
        public DateTime? Aenderung { get; set; }
        
        [StringLength(100)]
        public string Aenderungsgrund { get; set; } // StringLength = 100
        
        [Required]
        [StringLength(40)]
        public string Amsidnr { get; set; } // StringLength = 40 Zwangsfeld
        
        [StringLength(70)]
        public string Anrede { get; set; } // StringLength = 70
        
        [StringLength(15)]
        public string Arbeitgeber { get; set; } // StringLength = 15
        public decimal? AusbildungskostenMonatlich { get; set; }
        public DateTime? AustrittsdatumArbeitgeber { get; set; }
        
        [StringLength(40)]
        public string Bank1 { get; set; } // StringLength = 40
        
        [StringLength(40)]
        public string Bank2 { get; set; } // StringLength = 40
        
        [StringLength(15)]
        public string Bearbeiter { get; set; } // StringLength = 15
        
        [StringLength(200)]
        public string BelegteSparten { get; set; } // StringLength = 200
        
        [StringLength(60)]
        public string Beruf { get; set; } // StringLength = 60
        
        [StringLength(40)]
        public string Berufsstatus { get; set; } // StringLength = 40
        
        [StringLength(50)]
        public string Besitzverhaeltnis { get; set; } // StringLength = 50
        
        [StringLength(11)]
        public string Bic1 { get; set; } // StringLength = 11
        
        [StringLength(11)]
        public string Bic2 { get; set; } // StringLength = 11
        
        [StringLength(10)]
        public string Bilanzstichtag { get; set; } // StringLength = 10
        
        [StringLength(12)]
        public string Blz1 { get; set; } // StringLength = 12
        
        [StringLength(12)]
        public string Blz2 { get; set; } // StringLength = 12
        
        [StringLength(60)]
        public string Branche { get; set; }
        
        public decimal? Bruttojahresmietwert { get; set; }
        public decimal? Bruttojahresumsatz { get; set; }
        
        [StringLength(25)]
        public string Bundesland { get; set; } // StringLength = 25
        
        [StringLength(11)]
        public string Debitor { get; set; } // StringLength = 11
        public DateTime? DsgvoDeleteDate { get; set; }
        public DateTime? DsgvoLockDate { get; set; }
        public bool? DsgvoLocked { get; set; }
        
        [StringLength(20)]
        public string DtazvEntgelt { get; set; } // StringLength = 20
        public bool? Duzen { get; set; }
        public int? Einkommen { get; set; }
        public DateTime? EintrittsdatumArbeitgeber { get; set; }
        
        [StringLength(38)]
        public string EloGid { get; set; } // StringLength = 38
        
        [StringLength(80)]
        public string EmailGeschaeftlich { get; set; } // StringLength = 80
        
        [StringLength(80)]
        public string EmailPrivat { get; set; } // StringLength = 80
        public int? Erloeskonto { get; set; }
        public DateTime? ErlUwg7 { get; set; }
        public decimal? ErwerbsminderungsrenteTeil { get; set; }
        public decimal? ErwerbsminderungsrenteVoll { get; set; }
        
        [StringLength(30)]
        public string Familienstand { get; set; } // StringLength = 30
        
        [StringLength(35)]
        public string Fax { get; set; } // StringLength = 35
        
        [StringLength(30)]
        public string Finanzamt { get; set; } // StringLength = 30
        public decimal? GAgZuschuss { get; set; }
        public decimal? GAgZuschussProz { get; set; }
        public bool? GAvwl { get; set; }
        public bool? GB2b { get; set; }
        
        [StringLength(100)]
        public string GBetriebsart { get; set; } // StringLength = 100
        public int? GBetriebsartId { get; set; }
        
        [StringLength(200)]
        public string Geburtsname { get; set; } // StringLength = 200
        
        [StringLength(32)]
        public string Geburtsort { get; set; } // StringLength = 32
        public DateTime? Geburtstag { get; set; }
        
        [StringLength(10)]
        public string Geschlecht { get; set; } // StringLength = 10
        public decimal? GesetzlicheAltersrenteMonatlich { get; set; }
        public decimal? GesetzlicheBURenteMonatlich { get; set; }
        public decimal? GesetzlicheHinterbliebenenRenteMonatlich { get; set; }
        public bool? GesetzlichKrankenversichert { get; set; }
        public bool? GesetzlichRentenversichert { get; set; }
        public DateTime? GewuenschterRentenbeginn { get; set; }
        public DateTime? Gruendung { get; set; }
        public decimal? GrundstueckM { get; set; }
        
        [StringLength(50)]
        public string GTarif1 { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string GTarif2 { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string GTarif3 { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string GTarif4 { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string GTarif5 { get; set; } // StringLength = 50
        
        public DateTime? GueltigAb { get; set; }
        public DateTime? GueltigBis { get; set; }
        
        [StringLength(50)]
        public string GVersicherer1 { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string GVersicherer2 { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string GVersicherer3 { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string GVersicherer4 { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string GVersicherer5 { get; set; } // StringLength = 50
        
        [StringLength(51)]
        public string GVstAbzug { get; set; } // StringLength = 10
        public decimal? GVstAnteil { get; set; } // Anteil der VSt-Abzugsberechtigung in %
        public DateTime? GVstSeit { get; set; }
        public bool? GVtAccount { get; set; }
        public bool? GZuschussAltVt { get; set; }
        
        [StringLength(100)]
        public string Handelsregisternummer { get; set; } // StringLength = 100
        public bool? Hinterbliebenenrente { get; set; }
        
        [StringLength(40)]
        public string HistorieZuKunde { get; set; } // StringLength = 40
        public bool? Honorarkunde { get; set; }
        
        [StringLength(34)]
        public string Iban1 { get; set; } // StringLength = 34
        
        [StringLength(34)]
        public string Iban2 { get; set; } // StringLength = 34
        public DateTime? IdentDate { get; set; } // Identitätsnachweis
        public DateTime? IdentGueltigBis { get; set; }
        
        [StringLength(30)]
        public string IdentTyp { get; set; } // StringLength = 30
        public decimal? Inflationsrate { get; set; }
        
        [StringLength(20)]
        public string Info_01 { get; set; } // StringLength = 20
        
        [StringLength(30)]
        public string Informationsweg { get; set; } // StringLength = 30
        
        [StringLength(100)]
        public string InhaberGF { get; set; } // StringLength = 100
        
        [StringLength(15)]
        public string InterneNr { get; set; } // StringLength = 15
        
        [StringLength(200)]
        public string Internet { get; set; } // StringLength = 200
        
        [Required]
        public bool? IsHistorie { get; set; } // Zwangsfeld
        
        [StringLength(3)]
        public string IsoLand { get; set; } // StringLength = 3
        public bool? IsZukunft { get; set; }
        public decimal? Kapitalmarktzins { get; set; }
        
        [StringLength(40)]
        public string KeyIdentDate { get; set; } // StringLength = 40
        public int? Kinder { get; set; }
        
        [StringLength(20)]
        public string Kindergeldnummer { get; set; } // StringLength = 20
        public decimal? KinderLautSteuerkarte { get; set; }
        public bool? Kirchensteuer { get; set; }
        
        [StringLength(5)]
        public string Klasse { get; set; } // StringLength = 5
        
        [StringLength(12)]
        public string Konto1 { get; set; } // StringLength = 12
        
        [StringLength(12)]
        public string Konto2 { get; set; } // StringLength = 12
        
        [StringLength(100)]
        public string Kontobezeichnung1 { get; set; } // StringLength = 100
        
        [StringLength(100)]
        public string Kontobezeichnung2 { get; set; } // StringLength = 100
        
        [StringLength(40)]
        public string Kontoinhaber1 { get; set; } // StringLength = 40
        
        [StringLength(40)]
        public string Kontoinhaber2 { get; set; } // StringLength = 40
        public decimal? Kundeninkassokonto { get; set; }
        
        [StringLength(200)]
        public string Kundenname { get; set; } // StringLength = 200
        
        [StringLength(200)]
        public string KundennamePhonetisch { get; set; } // StringLength = 200
        
        [StringLength(200)]
        public string Kundentyp { get; set; } // StringLength = 200
        
        [StringLength(20)]
        public string Kundenverbindung { get; set; } // StringLength = 20
        public DateTime? KundeSeit { get; set; }
        
        [StringLength(50)]
        public string LageBetriebsgrundstuecks { get; set; } // StringLength = 50
        
        [StringLength(3)]
        public string Land { get; set; } // StringLength = 3
        
        [StringLength(50)]
        public string Landesname { get; set; } // StringLength = 50
        public DateTime? LetzterBesuch { get; set; }
        public decimal? LohnGehaltssumme { get; set; }
        public DateTime? MahnstopBis { get; set; }
        public DateTime? MaklervertragBis { get; set; }
        public DateTime? MaklervertragDatum { get; set; }
        
        [StringLength(50)]
        public string Mandant { get; set; } // StringLength = 50
        
        [StringLength(40)]
        public string MandantAmsidnr { get; set; } // StringLength = 40
        public decimal? MieteNebenkostenMonatlich { get; set; }
        public decimal? Mietsteigerung { get; set; }
        public int? Mitarbeiterzahl { get; set; }
        
        [StringLength(35)]
        public string Mobiltelefon { get; set; } // StringLength = 35
        
        [Required]
        [StringLength(40)]
        public string Name { get; set; } // StringLength = 40 Zwangsfeld

        [StringLength(200)]
        public string Name1 { get; set; } // StringLength = 200
        
        [StringLength(200)]
        public string Name2 { get; set; } // StringLength = 200
        
        [StringLength(200)]
        public string Name3 { get; set; } // StringLength = 200
        public decimal? NichtSelbstaendigeArbeitBruttoMonatlich { get; set; }
        public decimal? NichtSelbstaendigeArbeitNettoMonatlich { get; set; }
        
        [StringLength(50)]
        public string Ort { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string OrtPhonetisch { get; set; } // StringLength = 50
        
        [StringLength(15)]
        public string Partner { get; set; } // StringLength = 15
        
        [StringLength(30)]
        public string PAusbildung { get; set; } // StringLength = 30
        public DateTime? PAustrittVorag { get; set; }
        public bool? PBefristvt { get; set; }
        public DateTime? PBefristvtBis { get; set; }
        
        [StringLength(20)]
        public string PBeschaeftignungsverhaeltnis { get; set; } // StringLength = 20
        
        [StringLength(100)]
        public string PBildung { get; set; } // StringLength = 100
        public bool? Pep { get; set; }
        public DateTime? PersonalausweisAusstellungsdatum { get; set; }
        
        [StringLength(30)]
        public string PersonalausweisBehoerde { get; set; } // StringLength = 30
        public DateTime? PersonalausweisGueltigBis { get; set; }
        
        [StringLength(30)]
        public string PersonalausweisNr { get; set; } // StringLength = 30
        
        [StringLength(20)]
        public string Personalnummer { get; set; } // StringLength = 20
        
        [StringLength(30)]
        public string PFsbehoerde { get; set; } // StringLength = 30
        public DateTime? PFsdatum { get; set; }
        public DateTime? PFsgueltigab { get; set; }
        
        [StringLength(20)]
        public string PFsnummer { get; set; } // StringLength = 20
        public bool? PGehaltBbgKranken { get; set; }
        public bool? PGehaltBbgRente { get; set; }
        
        [StringLength(7)]
        public string Plz { get; set; } // StringLength = 7
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
        public bool? Rechexcel { get; set; }
        public bool? RechnungsMail { get; set; }
        public string Rechtsform { get; set; }
        
        [StringLength(100)]
        public string Repraesentant { get; set; } // StringLength = 100
        
        [StringLength(500)]
        public string S21_F1 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S21_F10 { get; set; } // StringLength = 500,
        
        [StringLength(500)]
        public string S21_F2 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S21_F3 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S21_F4 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S21_F5 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S21_F6 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S21_F7 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S21_F8 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S21_F9 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S22_F1 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S22_F10 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S22_F2 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S22_F3 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S22_F4 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S22_F5 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S22_F6 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S22_F7 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S22_F8 { get; set; } // StringLength = 500
        
        [StringLength(500)]
        public string S22_F9 { get; set; } // StringLength = 500
        
        [StringLength(40)]
        public string Sachbearbeiter { get; set; } // StringLength = 40
        
        [StringLength(250)]
        public string Schlagwoerter { get; set; } // StringLength = 250
        
        public decimal? SelbstaendigeArbeitNettoMonatlich { get; set; }
        public DateTime? Sepamandat { get; set; }
        
        [StringLength(35)]
        public string Sepamandatsreferenz { get; set; } // StringLength = 35
        
        [StringLength(30)]
        public string SepaSddType { get; set; } // StringLength = 30
        public decimal? SonstigeAlterseinkuenfteMonatlich { get; set; }
        public decimal? SonstigeEinkuenfteNettoMonatlich { get; set; }
        public decimal? SonstigeLaufendeKostenMonatlich { get; set; }
        
        [StringLength(12)]
        public string Sozialversicherungsnummer { get; set; } // StringLength = 12
        
        [StringLength(3)]
        public string Staatsangehoerigkeit { get; set; } // StringLength = 3
        
        [StringLength(15)]
        public string Status { get; set; } // StringLength = 15
        
        [StringLength(15)]
        public string SteuerIdentifikationsnummer { get; set; } // StringLength = 15
        
        [StringLength(10)]
        public string Steuerklasse { get; set; } // StringLength = 10
        
        [StringLength(20)]
        public string Steuernummer { get; set; } // StringLength = 20
        public DateTime? StichtagBruttojahresmietwert { get; set; }
        public DateTime? StichtagBruttojahresumsatz { get; set; }
        public DateTime? StichtagLohnGehaltssumme { get; set; }
        public DateTime? StichtagSubunternehmerAuftragswert { get; set; }
        public DateTime? StichtagSummeEigeneBauvorhaben { get; set; }
        public DateTime? StichtagWarenMaterialwertProJahr { get; set; }
        public DateTime? StopAbrechnungBis { get; set; }
        public DateTime? StopZahlungBis { get; set; }
        
        [StringLength(50)]
        public string Strasse { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string StrassePhonetisch { get; set; } // StringLength = 50
        public decimal? SubunternehmerAuftragswert { get; set; }
        public decimal? SummeEigeneBauvorhaben { get; set; }
        public DateTime? TaetigAufBetriebsgrundstueckSeit { get; set; }
        
        [StringLength(35)]
        public string TelefonGeschaeftlich { get; set; } // StringLength = 35
        
        [StringLength(35)]
        public string TelefonPrivat { get; set; } // StringLength = 35
        
        [StringLength(20)]
        public string Titel { get; set; } // StringLength = 20
        public bool? Trockenbett { get; set; }
        public bool? Ueberschwemmungsgebiet { get; set; }
        public bool? Umfriedet { get; set; }
        public int? Umsatz { get; set; }
        
        [StringLength(4)]
        public string UmsatzJahr { get; set; } // StringLength = 4
        public decimal? UnterhaltszahlungenMonatlich { get; set; }
        
        [StringLength(20)]
        public string USTIDNr { get; set; } // StringLength = 20
        public DateTime? Verstorben { get; set; }
        
        [StringLength(50)]
        public string Vm1 { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string Vm10 { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string Vm2 { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string Vm3 { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string Vm4 { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string Vm5 { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string Vm6 { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string Vm7 { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string Vm8 { get; set; } // StringLength = 50
        
        [StringLength(50)]
        public string Vm9 { get; set; } // StringLength = 50
        
        [StringLength(40)]
        public string VnMvertrag { get; set; } // StringLength = 40
        
        [StringLength(15)]
        public string Vnnummer { get; set; } // StringLength = 15
        public int? VnSepaPreNotificationtAge { get; set; }
        
        [StringLength(40)]
        public string Vorname { get; set; } // StringLength = 40
        public decimal? WarenMaterialwertProJahr { get; set; }
        public bool? Wasserschutzgebiet { get; set; }
        public string Zuordnung { get; set; } // Zwangsfeld, 'PRIVAT' , 'FIRMA'
        public ICollection<Vertrag> VertragModels { get; set; }

    }