using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assfinet.Shared.Entities;

public class Vertrag
{
    public int Id { get; set; }
    public Guid AmsId { get; set; } 
    public DateTime? Bearbeitet { get; set; }
    public string Sparte { get; set; }
    public string Details { get; set; }
    public string Vu { get; set; }
    public int VuNummer { get; set; }

    public string ComputedStatus { get; set; } //errechnetes Feld aus Status: dabei wird EIGEN aufgeteilt: mit Dokument: POLICE, mit Antragsdatum: ANTRAG, sonst EIGEN
    /// <summary>
    /// Gibt an ob dieser Datensatz lokal geändert und noch nicht von AMS bestätigt wurde
    /// </summary>
    public bool Dirty { get; set; } // automatisches Feld, soll nicht manuell gesetzt werden

    /// <summary>
    /// Die Lizenz der der Vertrag angehört
    /// </summary>
    public string License { get; set; }

    public DateTime LastSynchronisation { get; private set; }
    [JsonExtensionData] public IDictionary<string, JToken> AdditionalData { get; set; }
    public bool? Abbuchung { get; set; } // Zwangsfeld
    public DateTime? AblaufDt { get; set; } // Ablauf gem.Bedingung

    public string
        AbrEbene { get; set; } // StringLength = 15

    public bool? AbrechenbarerVertrag { get; set; } // Zwangsfeld
    public bool? AbrechnenueberEinzelpositionen { get; set; }
    public string AbrInfo { get; set; } // StringLength = 150
    public string Abschlussvermittler { get; set; } // StringLength = 50
    public string AendGrund { get; set; } // StringLength = 100
    public DateTime? AktiviertAm { get; set; }
    public string Amsidnr { get; set; } // StringLength = 40 Zwangsfeld, meine eindeutige interne Vertragnummer
    public DateTime? Anfrage { get; set; }
    public DateTime? Angebot { get; set; }
    public DateTime? AnpassungAm { get; set; }
    public DateTime? Antrag { get; set; }
    public int? AnzahlZahlungenProJahr { get; set; }
    public int? Anzcourtzahlung { get; set; }
    public decimal? ApBetrag { get; set; }
    public DateTime? ApBuchungsdatum { get; set; }
    public string ApInfo { get; set; } // StringLength = 10
    public decimal? Appro1 { get; set; }
    public decimal? Appro10 { get; set; }
    public decimal? Appro2 { get; set; }
    public decimal? Appro3 { get; set; }
    public decimal? Appro4 { get; set; }
    public decimal? Appro5 { get; set; }
    public decimal? Appro6 { get; set; }
    public decimal? Appro7 { get; set; }
    public decimal? Appro8 { get; set; }
    public decimal? Appro9 { get; set; }
    public decimal? ApZv { get; set; }
    public DateTime? Apzvbuch { get; set; }
    public decimal? ApZvpro1 { get; set; }
    public decimal? ApZvpro10 { get; set; }
    public decimal? ApZvpro2 { get; set; }
    public decimal? ApZvpro3 { get; set; }
    public decimal? ApZvpro4 { get; set; }
    public decimal? ApZvpro5 { get; set; }
    public decimal? ApZvpro6 { get; set; }
    public decimal? ApZvpro7 { get; set; }
    public decimal? ApZvpro8 { get; set; }
    public decimal? ApZvpro9 { get; set; }
    public string Art { get; set; } // StringLength = 10 Wirksamkeitsart
    public string Bankname { get; set; } // StringLength = 30
    public string Bearbeiter { get; set; } // StringLength = 15
    public DateTime? BeginnDt { get; set; } // Beginn gem.Bedingung
    public string Berater { get; set; } // StringLength = 15
    public bool? BeratungErforderlich { get; set; }
    public string Beratungsgebiet { get; set; } // StringLength = 50
    public string Beschreibung { get; set; } // StringLength = 150
    public DateTime? Bestaetigung { get; set; }
    public bool? Beteiligungsverhaeltnis { get; set; }
    public string BetreuungsvertragsNr { get; set; } // StringLength = 40
    public string BezugAppro1 { get; set; } // StringLength = 30
    public string BezugAppro10 { get; set; } // StringLength = 30
    public string BezugAppro2 { get; set; } // StringLength = 30
    public string BezugAppro3 { get; set; } // StringLength = 30
    public string BezugAppro4 { get; set; } // StringLength = 30
    public string BezugAppro5 { get; set; } // StringLength = 30
    public string BezugAppro6 { get; set; } // StringLength = 30
    public string BezugAppro7 { get; set; } // StringLength = 30
    public string BezugAppro8 { get; set; } // StringLength = 30
    public string BezugAppro9 { get; set; } // StringLength = 30
    public string BezugApzvpro1 { get; set; } // StringLength = 30
    public string BezugApzvpro10 { get; set; } // StringLength = 30
    public string BezugApzvpro2 { get; set; } // StringLength = 30
    public string BezugApzvpro3 { get; set; } // StringLength = 30
    public string BezugApzvpro4 { get; set; } // StringLength = 30
    public string BezugApzvpro5 { get; set; } // StringLength = 30
    public string BezugApzvpro6 { get; set; } // StringLength = 30
    public string BezugApzvpro7 { get; set; } // StringLength = 30
    public string BezugApzvpro8 { get; set; } // StringLength = 30
    public string BezugApzvpro9 { get; set; } // StringLength = 30
    public string BezugDypro1 { get; set; } // StringLength = 30
    public string BezugDypro10 { get; set; } // StringLength = 30
    public string BezugDypro2 { get; set; } // StringLength = 30
    public string BezugDypro3 { get; set; } // StringLength = 30
    public string BezugDypro4 { get; set; } // StringLength = 30
    public string BezugDypro5 { get; set; } // StringLength = 30
    public string BezugDypro6 { get; set; } // StringLength = 30
    public string BezugDypro7 { get; set; } // StringLength = 30
    public string BezugDypro8 { get; set; } // StringLength = 30
    public string BezugDypro9 { get; set; } // StringLength = 30
    public string BezugVmpro1 { get; set; } // StringLength = 30
    public string BezugVmpro10 { get; set; } // StringLength = 30
    public string BezugVmpro2 { get; set; } // StringLength = 30
    public string BezugVmpro3 { get; set; } // StringLength = 30
    public string BezugVmpro4 { get; set; } // StringLength = 30
    public string BezugVmpro5 { get; set; } // StringLength = 30
    public string BezugVmpro6 { get; set; } // StringLength = 30
    public string BezugVmpro7 { get; set; } // StringLength = 30
    public string BezugVmpro8 { get; set; } // StringLength = 30
    public string BezugVmpro9 { get; set; } // StringLength = 30
    public string Bic { get; set; } // StringLength = 11
    public decimal? Bimonthvalue { get; set; }
    public decimal? BisherigeJahresNettoPraemie { get; set; }
    public string Blz { get; set; } // StringLength = 8
    public decimal? Bonusbetrag { get; set; }
    public DateTime? Bonuseingang { get; set; }
    public decimal? BruttopraemieGemaessZahlweise { get; set; }
    public bool? BruttoVertrag { get; set; }
    public bool? BuchenAutomatisch { get; set; }
    public decimal? BwSumme { get; set; }
    public decimal? Bwsummezv { get; set; }
    public bool? Cbc { get; set; }
    public string Ccxid { get; set; } // StringLength = 15
    public string Ccximport { get; set; } // StringLength = 15
    public DateTime? CourtageAb { get; set; }
    public decimal? Courtagesplit { get; set; }
    public decimal? CourtagesplitBetrag { get; set; }
    public string CourtageBezugsgroesseFormel { get; set; } // StringLength = 30
    public DateTime? CourtageBis { get; set; }
    public decimal? CourtageFormelBetrag { get; set; }
    public decimal? CourtageProzent { get; set; }
    public string CourtageZahlweise { get; set; } // StringLength = 15
    public decimal? Courtformelbetragzv { get; set; }
    public string Courtformelzv { get; set; } // StringLength = 30
    public bool? CourtManuell { get; set; }
    public decimal? Courtprozzv { get; set; }
    public decimal? Courtprozzvb { get; set; }
    public DateTime? DeckungBis { get; set; }
    public DateTime? DeckungVon { get; set; }
    public DateTime? Defzeit { get; set; }
    public decimal? DifferenzCourtage { get; set; }
    public decimal? DifferenzCourtageBetrag { get; set; }
    public int? Digistatus { get; set; }
    public DateTime? DigistatusDatum { get; set; }
    public DateTime? Dokument { get; set; }
    public DateTime? DsgvoDeleteDate { get; set; }
    public DateTime? DsgvoLockDate { get; set; }
    public bool? DsgvoLocked { get; set; }
    public DateTime? DynamikAb { get; set; }
    public decimal? Dyvm1 { get; set; }
    public decimal? Dyvm10 { get; set; }
    public decimal? Dyvm2 { get; set; }
    public decimal? Dyvm3 { get; set; }
    public decimal? Dyvm4 { get; set; }
    public decimal? Dyvm5 { get; set; }
    public decimal? Dyvm6 { get; set; }
    public decimal? Dyvm7 { get; set; }
    public decimal? Dyvm8 { get; set; }
    public decimal? Dyvm9 { get; set; }
    public decimal? EffektivcourtageProzent { get; set; }
    public decimal? EigenerAnteilInMitversicherung { get; set; }
    public bool? EinzelpraemienErfassen { get; set; }
    public string EloGid { get; set; } // StringLength = 38
    public int? Erloeskonto { get; set; }
    public string Extid { get; set; } // StringLength = 100
    public DateTime? Faellig { get; set; }
    public string FeeArt { get; set; } // StringLength = 30
    public decimal? FeeBetrag { get; set; }
    public decimal? FeeJahresZahlBetrag { get; set; }
    public decimal? FeePraemie { get; set; }
    public decimal? FeeProz { get; set; }
    public decimal? FeeProzB { get; set; }
    public decimal? FeeProzV { get; set; }
    public DateTime? FestwertPraemieVom { get; set; }
    public decimal? FNettoJPraemie { get; set; }
    public DateTime? FPoliceGeprueft { get; set; }
    public bool? FPoliceVorhanden { get; set; }
    public string Fronter { get; set; } // StringLength = 50
    public DateTime? FrontingPolice { get; set; }
    public DateTime? GdvDatenVom { get; set; }
    public bool? GdvIgnore { get; set; }
    public decimal? GebuehrNetto { get; set; }
    public decimal? GebuehrZw { get; set; }
    public string GekuendigtVon { get; set; } // StringLength = 2
    public DateTime? GekuendWv { get; set; }

    public string
        Gesellschaft
    {
        get;
        set;
    } // StringLength = 50 Zwangsfeld, Gesellschaft des Vertrages, muss "Matchcode" in api/v1/Ams/Gesellschaft

    public string Gevo { get; set; } // StringLength = 150
    public int? Gevoid { get; set; }
    public string HaftungMakler { get; set; } // StringLength = 30
    public string HaftungVm1 { get; set; } // StringLength = 30
    public string HaftungVm10 { get; set; } // StringLength = 30
    public string HaftungVm2 { get; set; } // StringLength = 30
    public string HaftungVm3 { get; set; } // StringLength = 30
    public string HaftungVm4 { get; set; } // StringLength = 30
    public string HaftungVm5 { get; set; } // StringLength = 30
    public string HaftungVm6 { get; set; } // StringLength = 30
    public string HaftungVm7 { get; set; } // StringLength = 30
    public string HaftungVm8 { get; set; } // StringLength = 30
    public string HaftungVm9 { get; set; } // StringLength = 30
    public bool? HatFestwertBeteiligung { get; set; }
    public DateTime? Historiendatum { get; set; }
    public string Historiengrund { get; set; } // StringLength = 100
    public string HistorieZuVertrag { get; set; } // StringLength = 40
    public decimal? HonorarVm1 { get; set; }
    public decimal? HonorarVm10 { get; set; }
    public decimal? HonorarVm2 { get; set; }
    public decimal? HonorarVm3 { get; set; }
    public decimal? HonorarVm4 { get; set; }
    public decimal? HonorarVm5 { get; set; }
    public decimal? HonorarVm6 { get; set; }
    public decimal? HonorarVm7 { get; set; }
    public decimal? HonorarVm8 { get; set; }
    public decimal? HonorarVm9 { get; set; }
    public string Hpvahb { get; set; } // StringLength = 15
    public bool? HpvGruppe { get; set; }
    public string Iban { get; set; } // StringLength = 34
    public string IndexanpassungAbrechnung { get; set; } // StringLength = 15
    public DateTime? IndexanpassungAm { get; set; }
    public decimal? IndexanpassungNjpAlt { get; set; }
    public decimal? IndexanpassungNjpNeu { get; set; }
    public string Inhaber { get; set; } // StringLength = 27
    public bool? Inkasso { get; set; }
    public string Inkassoint { get; set; } // StringLength = 50
    public decimal? Inkassomaklergeb { get; set; }
    public bool? InkassoVm { get; set; }
    public string InterneNr { get; set; } // StringLength = 50 Interne Nr.
    public bool? IntKlaerung { get; set; }
    public DateTime? InvitatioDatum { get; set; }
    public bool? IsHistorie { get; set; } // Zwangsfeld
    public bool? IsJPraemie { get; set; }
    public bool? IsKorrespondenzMakler { get; set; }
    public decimal? Jahrescourtage { get; set; }

    public decimal? Jahrespraemie { get; set; } //nicht nur dieses Feld alleine füllen, da AMS Jahresprämie errechnet

// Netto+Gebühr+UnterjährigZuschlag+Zahlweise+VersSteuer
    public decimal? Jahressteuerbetrag { get; set; }
    public DateTime? KenntnisAm { get; set; }
    public string Key { get; set; } // StringLength = 40 Zwangsfeld, Vater - Datensatz, also zugehöriger Kunde.Amsidnr
    public string KeyAngebot { get; set; } // StringLength = 40
    public string KeyAntrag { get; set; } // StringLength = 40
    public string KeyBestaet { get; set; } // StringLength = 40
    public string KeyFaellig { get; set; } // StringLength = 40
    public string KeyFrontingPolice { get; set; } // StringLength = 15
    public string KeyGdvDatenVom { get; set; } // StringLength = 40
    public string KeyGekuend { get; set; } // StringLength = 40
    public string KeyGekuendWv { get; set; } // StringLength = 15
    public string KeyLokalPolice { get; set; } // StringLength = 15
    public string KeyMvertrag { get; set; } // StringLength = 40
    public string KeyNachtrag { get; set; } // StringLength = 40
    public string KeyPolice { get; set; } // StringLength = 40
    public string KeyProtokoll { get; set; } // StringLength = 40
    public string KeyRenta { get; set; } // StringLength = 15
    public string KeyVersbestaet { get; set; } // StringLength = 15
    public decimal? Kickback { get; set; }
    public decimal? KickbackBetrag { get; set; }
    public string Konto { get; set; } // StringLength = 12
    public string Kommakler { get; set; }
    public string Komvers { get; set; }
    public string Kontobezeichnung { get; set; } // StringLength = 100
    public DateTime? KorrespondenzMaklerBis { get; set; }
    public int? Kostenstelle { get; set; }
    public DateTime? Kuendigung { get; set; }
    public DateTime? LetzeAnfrage { get; set; }
    public DateTime? LetzteFaelligkeit { get; set; }
    public decimal? LetzteNettopraemie { get; set; }
    public decimal? LetzteProvision { get; set; }
    public DateTime? LetzterNachtrag { get; set; }
    public decimal? LokalCourtage { get; set; }
    public decimal? LokalCourtageBetrag { get; set; }
    public decimal? LokalFee { get; set; }
    public decimal? LokalFeeBetrag { get; set; }
    public DateTime? LokalMahnDatum { get; set; }
    public DateTime? LokalPolice { get; set; }
    public decimal? LokalSteuer { get; set; }
    public decimal? LokalSteuerBetrag { get; set; }
    public DateTime? LtFaelligBis { get; set; }
    public decimal? LtPraemiebrutto { get; set; }
    public string Kommentar { get; set; } // StringLength = 200
    public DateTime? MahnstopBis { get; set; }
    public bool? MaklerFuehrtVersSteuerAb { get; set; }
    public string Matchcode { get; set; } // StringLength = 20
    public decimal? MindestJahresNettopraermie { get; set; }
    public string ModellVmprovis { get; set; } // StringLength = 30
    public decimal? MPraemieFronting { get; set; }
    public string NachtragNr { get; set; } // StringLength = 10
    public string NeedVstCheck { get; set; } // StringLength = 4
    public bool? Nettoisiert { get; set; }
    public bool? NonAdmittedFinc { get; set; }
    public string NVnr { get; set; } // StringLength = 40
    public decimal? Overrider { get; set; }
    public decimal? OverriderBetrag { get; set; }
    public string Parentid { get; set; } // StringLength = 15
    public decimal? PraemieNetto { get; set; }
    public string Pricing { get; set; } // StringLength = 150
    public string Produkt { get; set; } // StringLength = 50
    public string Produktgruppe { get; set; } // StringLength = 50
    public string ProduktgruppeId { get; set; } // StringLength = 15
    public decimal? ProgrammCourtage { get; set; }
    public decimal? ProgrammCourtageBetrag { get; set; }
    public string ProviMaxAp { get; set; }
    public string ProviMaxDy { get; set; } // StringLength = 30
    public string ProviMaxFp { get; set; } // StringLength = 30
    public DateTime? Provisionsreferenzdatum { get; set; }
    public string ProvisMonat { get; set; } // StringLength = 2
    public string ProvisTag { get; set; } // StringLength = 2
    public bool? Prtausschluss { get; set; }
    public decimal? Rabatt { get; set; }
    public DateTime? RechnungAnNl { get; set; }
    public DateTime? RechnungFwDatum { get; set; }
    public bool? RechnungsMail { get; set; }
    public DateTime? Renta { get; set; }
    public bool? RGDruckstop { get; set; }
    public string RisikoAllgemein { get; set; } // StringLength = 200
    public string RisikoOrt { get; set; } // StringLength = 40
    public string RisikoPlz { get; set; } // StringLength = 10
    public string RisikoStrasse { get; set; } // StringLength = 50
    public string Risikotraeger { get; set; } // StringLength = 30
    public string Rvart { get; set; } // StringLength = 50
    public string RVKumulnr { get; set; } // StringLength = 20
    public int? Rvnummer { get; set; }
    public decimal? RVRelKumulsumme { get; set; }
    public decimal? RVRelSumme { get; set; }
    public string S2_01 { get; set; } // StringLength = 500 Seite 2 Feld 1
    public string S2_02 { get; set; } // StringLength = 500 Seite 2 Feld 2
    public string S2_03 { get; set; } // StringLength = 500
    public string S2_04 { get; set; } // StringLength = 500
    public string S2_05 { get; set; } // StringLength = 500
    public string S2_06 { get; set; } // StringLength = 500
    public string S2_07 { get; set; } // StringLength = 500
    public string S2_08 { get; set; } // StringLength = 500
    public string S2_09 { get; set; } // StringLength = 500
    public string S2_10 { get; set; } // StringLength = 500
    public string S2_11 { get; set; } // StringLength = 500
    public string S2_12 { get; set; } // StringLength = 500
    public string S2_13 { get; set; } // StringLength = 500

    public string
        Sachbearbeiter { get; set; } // StringLength = 40

    public bool? Sammelvertrag { get; set; } // Zwangsfeld
    public string Sammelvertragsnr { get; set; } // StringLength = 40
    public string SammelVtId { get; set; } // StringLength = 15
    public string SchadenBetJaNein { get; set; } // StringLength = 4
    public string Schlagwoerter { get; set; } // StringLength = 250 READONLY
    public string SchwebeZuVertrag { get; set; } // StringLength = 15
    public DateTime? SEPAEinzugsmandat { get; set; }
    public string SEPAMandatsreferenz { get; set; } // StringLength = 35
    public string SepaSddType { get; set; } // StringLength = 30
    public bool? Sicherungsschein { get; set; }
    public string Sourceid { get; set; } // StringLength = 15
    public bool? SpartenberechnAufschub { get; set; }
    public bool? SpartenberechnungAus { get; set; }
    public decimal? SpartenCounter { get; set; }
    public DateTime? SperrdatumVUAbrechnung { get; set; }
    public string StandNr { get; set; } // StringLength = 10
    public decimal? StatCharges { get; set; }
    public decimal? StatChargesBetrag { get; set; }
    public string Statpolice { get; set; } // StringLength = 50
    public DateTime? StatpoliceDate { get; set; }
    public string Statpraemie { get; set; } // StringLength = 50
    public DateTime? StatpraemieDate { get; set; }

    public string Status { get; set; } // StringLength = 9 Zwangsfeld,

// Status des Vertrages: "ANFRAGE","ANGEBOT","EIGEN","FREMD","FREMDTEIL","GESPERRT","RUHEND","STORNO","INFO"
    public string Statusgrund { get; set; } // StringLength = 60
    public decimal? Steuer { get; set; }
    public string Steuerland { get; set; } // StringLength = 2
    public decimal? SteuerZw { get; set; }
    public DateTime? StopAbrechnungBis { get; set; }
    public DateTime? StopZahlungBis { get; set; }
    public DateTime? Storno { get; set; }
    public decimal? Stornoges { get; set; }
    public int? Stornohaft { get; set; }
    public decimal? StornoVm1 { get; set; }
    public decimal? StornoVm10 { get; set; }
    public decimal? StornoVm2 { get; set; }
    public decimal? StornoVm3 { get; set; }
    public decimal? StornoVm4 { get; set; }
    public decimal? StornoVm5 { get; set; }
    public decimal? StornoVm6 { get; set; }
    public decimal? StornoVm7 { get; set; }
    public decimal? StornoVm8 { get; set; }
    public decimal? StornoVm9 { get; set; }
    public decimal? Sumbuildings { get; set; }
    public decimal? Sumcontents { get; set; }
    public decimal? Sumpd { get; set; }
    public decimal? Sumstocks { get; set; }
    public string TeilerAppro1 { get; set; } // StringLength = 4
    public string TeilerAppro10 { get; set; } // StringLength = 4
    public string TeilerAppro2 { get; set; } // StringLength = 4
    public string TeilerAppro3 { get; set; } // StringLength = 4
    public string TeilerAppro4 { get; set; } // StringLength = 4
    public string TeilerAppro5 { get; set; } // StringLength = 4
    public string TeilerAppro6 { get; set; } // StringLength = 4
    public string TeilerAppro7 { get; set; } // StringLength = 4
    public string TeilerAppro8 { get; set; } // StringLength = 4
    public string TeilerAppro9 { get; set; } // StringLength = 4
    public string TeilerApzvpro1 { get; set; } // StringLength = 4
    public string TeilerApzvpro10 { get; set; } // StringLength = 4
    public string TeilerApzvpro2 { get; set; } // StringLength = 4
    public string TeilerApzvpro3 { get; set; } // StringLength = 4
    public string TeilerApzvpro4 { get; set; } // StringLength = 4
    public string TeilerApzvpro5 { get; set; } // StringLength = 4
    public string TeilerApzvpro6 { get; set; } // StringLength = 4
    public string TeilerApzvpro7 { get; set; } // StringLength = 4
    public string TeilerApzvpro8 { get; set; } // StringLength = 4
    public string TeilerApzvpro9 { get; set; } // StringLength = 4
    public string TeilerDypro1 { get; set; } // StringLength = 4
    public string TeilerDypro10 { get; set; } // StringLength = 4
    public string TeilerDypro2 { get; set; } // StringLength = 4
    public string TeilerDypro3 { get; set; } // StringLength = 4
    public string TeilerDypro4 { get; set; } // StringLength = 4
    public string TeilerDypro5 { get; set; } // StringLength = 4
    public string TeilerDypro6 { get; set; } // StringLength = 4
    public string TeilerDypro7 { get; set; } // StringLength = 4
    public string TeilerDypro8 { get; set; } // StringLength = 4
    public string TeilerDypro9 { get; set; } // StringLength = 4
    public string TeilerVmpro1 { get; set; } // StringLength = 4
    public string TeilerVmpro10 { get; set; } // StringLength = 4
    public string TeilerVmpro2 { get; set; } // StringLength = 4
    public string TeilerVmpro3 { get; set; } // StringLength = 4
    public string TeilerVmpro4 { get; set; } // StringLength = 4
    public string TeilerVmpro5 { get; set; } // StringLength = 4
    public string TeilerVmpro6 { get; set; } // StringLength = 4
    public string TeilerVmpro7 { get; set; } // StringLength = 4
    public string TeilerVmpro8 { get; set; } // StringLength = 4

    public string
        TeilerVmpro9 { get; set; } // StringLength = 4

    public string
        Typ
    {
        get;
        set;
    } // StringLength = 50 Zwangsfeld, Sparte des Vertrages, muss vorkommen in Tabelle-Sparte mit Feld-Sparte.

// Feld "Spartenkuerzel" in api/v1/Ams/Sparte
    public decimal? Unterjaehrigkeitszuschlag { get; set; }
    public string Verkaufsprodukt { get; set; } // StringLength = 30
    public bool? Verlaengerung { get; set; }
    public string Vermittlerkonto { get; set; } // StringLength = 50
    public DateTime? VersBestaet { get; set; }

    public DateTime?
        Vertragsablauf { get; set; } // Zwangsfeld, wann ist Vertragsablauf

    public DateTime? Vertragsbeginn { get; set; } // Zwangsfeld, wann ist Vertragsbeginn

    public string VertragsCheck { get; set; } // StringLength = 50
    public string VertragsNr { get; set; } // StringLength = 40
    public string VertragsnrAusdruck { get; set; } // StringLength = 40
    public string Vertriebskanal { get; set; } // StringLength = 50
    public string Vm1 { get; set; } // StringLength = 50
    public string Vm10 { get; set; } // StringLength = 50
    public string Vm2 { get; set; } // StringLength = 50
    public string Vm3 { get; set; } // StringLength = 50
    public string Vm4 { get; set; } // StringLength = 50
    public string Vm5 { get; set; } // StringLength = 50
    public string Vm6 { get; set; } // StringLength = 50
    public string Vm7 { get; set; } // StringLength = 50
    public string Vm8 { get; set; } // StringLength = 50
    public string Vm9 { get; set; } // StringLength = 50
    public decimal? Vmpro1 { get; set; }
    public decimal? Vmpro10 { get; set; }
    public decimal? Vmpro2 { get; set; }
    public decimal? Vmpro3 { get; set; }
    public decimal? Vmpro4 { get; set; }
    public decimal? Vmpro5 { get; set; }
    public decimal? Vmpro6 { get; set; }
    public decimal? Vmpro7 { get; set; }
    public decimal? Vmpro8 { get; set; }
    public decimal? Vmpro9 { get; set; }
    public int? VorschaedenBetrag { get; set; }
    public int? VorschaedenZahl { get; set; }
    public string VorvertragNr { get; set; } // StringLength = 40
    public string VorvertragVU { get; set; } // StringLength = 50
    public string VtheaderId { get; set; } // StringLength = 40
    public int? VtSepaPreNotificationtAge { get; set; }
    public string Waehrung { get; set; } // StringLength = 3
    public DateTime? Wiedervorlage { get; set; }
    public DateTime? WirksamAb { get; set; }
    public DateTime? WirksamBis { get; set; }
    public int? ZahlerAktiv { get; set; }
    public string Zahlweise { get; set; } // StringLength = 15
    public int? Zeichnungsjahr { get; set; }
    public decimal? ZPraemie { get; set; }
    public decimal? ZQuote { get; set; }
    public DateTime? Zugangsdatum { get; set; }
    public int? ZugangsdatumJjjj { get; set; }
    public int? ZugangsdatumJjjjmm { get; set; }
    public string Zuordnung { get; set; } // StringLength = 6
    public decimal? Zuschlagbetrag { get; set; }
    public decimal? ZuschlagbetragZw { get; set; }
    public virtual KrvSparte KrvSparte { get; set; }
}