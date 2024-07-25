using System.ComponentModel.DataAnnotations;

namespace Assfinet.Shared.Entities;

public class VertragDetails
{
    public int VertragId { get; set; }
    [StringLength(150)]
    public string AbrInfo { get; set; }
    [StringLength(50)]
    public string Abschlussvermittler { get; set; }
    [StringLength(100)]
    public string AendGrund { get; set; }
    public DateTime? Anfrage { get; set; }
    public DateTime? Angebot { get; set; }
    public DateTime? AnpassungAm { get; set; }
    public DateTime? Antrag { get; set; }
    public int? AnzahlZahlungenProJahr { get; set; }
    public int? Anzcourtzahlung { get; set; }
    [StringLength(10)]
    public string ApInfo { get; set; }
    [StringLength(10)]
    public string Art { get; set; }
    [StringLength(30)]
    public string Berater { get; set; }
    public bool? BeratungErforderlich { get; set; }
    [StringLength(50)]
    public string Beratungsgebiet { get; set; }
    [StringLength(150)]
    public string Beschreibung { get; set; }
    public DateTime? Bestaetigung { get; set; }
    public bool? Beteiligungsverhaeltnis { get; set; }
    [StringLength(40)]
    public string BetreuungsvertragsNr { get; set; }
    [StringLength(30)]
    public string BezugAppro1 { get; set; }
    [StringLength(30)]
    public string BezugAppro10 { get; set; }
    [StringLength(30)]
    public string BezugAppro2 { get; set; }
    [StringLength(30)]
    public string BezugAppro3 { get; set; }
    [StringLength(30)]
    public string BezugAppro4 { get; set; }
    [StringLength(30)]
    public string BezugAppro5 { get; set; }
    [StringLength(30)]
    public string BezugAppro6 { get; set; }
    [StringLength(30)]
    public string BezugAppro7 { get; set; }
    [StringLength(30)]
    public string BezugAppro8 { get; set; }
    [StringLength(30)]
    public string BezugAppro9 { get; set; }
    [StringLength(30)]
    public string BezugApzvpro1 { get; set; }
    [StringLength(30)]
    public string BezugApzvpro10 { get; set; }
    [StringLength(30)]
    public string BezugApzvpro2 { get; set; }
    [StringLength(30)]
    public string BezugApzvpro3 { get; set; }
    [StringLength(30)]
    public string BezugApzvpro4 { get; set; }
    [StringLength(30)]
    public string BezugApzvpro5 { get; set; }
    [StringLength(30)]
    public string BezugApzvpro6 { get; set; }
    [StringLength(30)]
    public string BezugApzvpro7 { get; set; }
    [StringLength(30)]
    public string BezugApzvpro8 { get; set; }
    [StringLength(30)]
    public string BezugApzvpro9 { get; set; }
    [StringLength(30)]
    public string BezugDypro1 { get; set; }
    [StringLength(30)]
    public string BezugDypro10 { get; set; }
    [StringLength(30)]
    public string BezugDypro2 { get; set; }
    [StringLength(30)]
    public string BezugDypro3 { get; set; }
    [StringLength(30)]
    public string BezugDypro4 { get; set; }
    [StringLength(30)]
    public string BezugDypro5 { get; set; }
    [StringLength(30)]
    public string BezugDypro6 { get; set; }
    [StringLength(30)]
    public string BezugDypro7 { get; set; }
    [StringLength(30)]
    public string BezugDypro8 { get; set; }
    [StringLength(30)]
    public string BezugDypro9 { get; set; }
    [StringLength(30)]
    public string BezugVmpro1 { get; set; }
    [StringLength(30)]
    public string BezugVmpro10 { get; set; }
    [StringLength(30)]
    public string BezugVmpro2 { get; set; }
    [StringLength(30)]
    public string BezugVmpro3 { get; set; }
    [StringLength(30)]
    public string BezugVmpro4 { get; set; }
    [StringLength(30)]
    public string BezugVmpro5 { get; set; }
    [StringLength(30)]
    public string BezugVmpro6 { get; set; }
    [StringLength(30)]
    public string BezugVmpro7 { get; set; }
    [StringLength(30)]
    public string BezugVmpro8 { get; set; }
    [StringLength(30)]
    public string BezugVmpro9 { get; set; }
    public decimal? Bimonthvalue { get; set; }
    public decimal? BisherigeJahresNettoPraemie { get; set; }
    public decimal? Bonusbetrag { get; set; }
    public DateTime? Bonuseingang { get; set; }
    public decimal? BruttopraemieGemaessZahlweise { get; set; }
    public bool? BruttoVertrag { get; set; }
    public bool? BuchenAutomatisch { get; set; }
    public bool? Cbc { get; set; }
    [StringLength(15)]
    public string Ccxid { get; set; }
    [StringLength(15)]
    public string Ccximport { get; set; }
    public DateTime? CourtageAb { get; set; }
    public decimal? Courtagesplit { get; set; }
    public decimal? CourtagesplitBetrag { get; set; }
    [StringLength(30)]
    public string CourtageBezugsgroesseFormel { get; set; }
    public DateTime? CourtageBis { get; set; }
    public decimal? CourtageFormelBetrag { get; set; }
    public decimal? CourtageProzent { get; set; }
    [StringLength(15)]
    public string CourtageZahlweise { get; set; }
    public decimal? Courtformelbetragzv { get; set; }
    [StringLength(30)]
    public string Courtformelzv { get; set; }
    public bool? CourtManuell { get; set; }
    public decimal? Courtprozzv { get; set; }
    public decimal? Courtprozzvb { get; set; }
    public DateTime? DeckungBis { get; set; }
    public DateTime? DeckungVon { get; set; }
    public DateTime? Defzeit { get; set; }
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
    public bool? EinzelpraemienErfassen { get; set; }
    [StringLength(38)]
    public string EloGid { get; set; }
    public int? Erloeskonto { get; set; }
    [StringLength(100)]
    public string Extid { get; set; }
    public DateTime? Faellig { get; set; }
    [StringLength(30)]
    public string FeeArt { get; set; }
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
    [StringLength(50)]
    public string Fronter { get; set; }
    public DateTime? FrontingPolice { get; set; }
    public DateTime? GdvDatenVom { get; set; }
    public bool? GdvIgnore { get; set; }
    public decimal? GebuehrNetto { get; set; }
    public decimal? GebuehrZw { get; set; }
    [StringLength(2)]
    public string GekuendigtVon { get; set; }
    public DateTime? GekuendWv { get; set; }
    [StringLength(50)]
    public string Gesellschaft { get; set; }
    [StringLength(150)]
    public string Gevo { get; set; }
    public int? Gevoid { get; set; }
    [StringLength(30)]
    public string HaftungMakler { get; set; }
    [StringLength(30)]
    public string HaftungVm1 { get; set; }
    [StringLength(30)]
    public string HaftungVm10 { get; set; }
    [StringLength(30)]
    public string HaftungVm2 { get; set; }
    [StringLength(30)]
    public string HaftungVm3 { get; set; }
    [StringLength(30)]
    public string HaftungVm4 { get; set; }
    [StringLength(30)]
    public string HaftungVm5 { get; set; }
    [StringLength(30)]
    public string HaftungVm6 { get; set; }
    [StringLength(30)]
    public string HaftungVm7 { get; set; }
    [StringLength(30)]
    public string HaftungVm8 { get; set; }
    [StringLength(30)]
    public string HaftungVm9 { get; set; }
    public bool? HatFestwertBeteiligung { get; set; }
    public DateTime? InvitatioDatum { get; set; }
    [Required]
    public bool? IsHistorie { get; set; }
    public bool? IsJPraemie { get; set; }
    public bool? IsKorrespondenzMakler { get; set; }
    public decimal? Jahrescourtage { get; set; }
    public decimal? Kickback { get; set; }
    public decimal? KickbackBetrag { get; set; }
    [StringLength(12)]
    public string Konto { get; set; }
    public string Kommakler { get; set; }
    public string Komvers { get; set; }
    [StringLength(100)]
    public string Kontobezeichnung { get; set; }
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
    [StringLength(200)]
    public string Kommentar { get; set; }
    public DateTime? MahnstopBis { get; set; }
    public bool? MaklerFuehrtVersSteuerAb { get; set; }
    [StringLength(20)]
    public string Matchcode { get; set; }
    public decimal? MindestJahresNettopraermie { get; set; }
    [StringLength(30)]
    public string ModellVmprovis { get; set; }
    public decimal? MPraemieFronting { get; set; }
    [StringLength(10)]
    public string NachtragNr { get; set; }
    [StringLength(4)]
    public string NedVstCheck { get; set; }
    public bool? Nettoisiert { get; set; }
    public bool? NonAdmittedFinc { get; set; }
    [StringLength(40)]
    public string NVnr { get; set; }
    public decimal? Overrider { get; set; }
    public decimal? OverriderBetrag { get; set; }
    [StringLength(15)]
    public string Parentid { get; set; }
    [StringLength(150)]
    public string Pricing { get; set; }
    [StringLength(50)]
    public string Produkt { get; set; }
    [StringLength(50)]
    public string Produktgruppe { get; set; }
    [StringLength(15)]
    public string ProduktgruppeId { get; set; }
    [StringLength(30)]
    public string ProviMaxAp { get; set; }
    [StringLength(30)]
    public string ProviMaxDy { get; set; }
    [StringLength(30)]
    public string ProviMaxFp { get; set; }
    public DateTime? Provisionsreferenzdatum { get; set; }
    [StringLength(2)]
    public string ProvisMonat { get; set; }
    [StringLength(2)]
    public string ProvisTag { get; set; }
    public bool? Prtausschluss { get; set; }
    public decimal? Rabatt { get; set; }
    public DateTime? RechnungAnNl { get; set; }
    public DateTime? RechnungFwDatum { get; set; }
    public bool? RechnungsMail { get; set; }
    public DateTime? Renta { get; set; }
    public bool? RGDruckstop { get; set; }
    [StringLength(200)]
    public string RisikoAllgemein { get; set; }
    [StringLength(40)]
    public string RisikoOrt { get; set; }
    [StringLength(10)]
    public string RisikoPlz { get; set; }
    [StringLength(50)]
    public string RisikoStrasse { get; set; }
    [StringLength(30)]
    public string Risikotraeger { get; set; }
    [StringLength(50)]
    public string Rvart { get; set; }
    [StringLength(20)]
    public string RVKumulnr { get; set; }
    public int? Rvnummer { get; set; }
    public decimal? RVRelKumulsumme { get; set; }
    public decimal? RVRelSumme { get; set; }
    [StringLength(500)]
    public string S2_01 { get; set; }
    [StringLength(500)]
    public string S2_02 { get; set; }
    [StringLength(500)]
    public string S2_03 { get; set; }
    [StringLength(500)]
    public string S2_04 { get; set; }
    [StringLength(500)]
    public string S2_05 { get; set; }
    [StringLength(500)]
    public string S2_06 { get; set; }
    [StringLength(500)]
    public string S2_07 { get; set; }
    [StringLength(500)]
    public string S2_08 { get; set; }
    [StringLength(500)]
    public string S2_09 { get; set; }
    [StringLength(500)]
    public string S2_10 { get; set; }
    [StringLength(500)]
    public string S2_11 { get; set; }
    [StringLength(500)]
    public string S2_12 { get; set; }
    [StringLength(500)]
    public string S2_13 { get; set; }
    [StringLength(40)]
    public string Sachbearbeiter { get; set; }
    [Required]
    public bool? Sammelvertrag { get; set; }
    [StringLength(40)]
    public string Sammelvertragsnr { get; set; }
    [StringLength(15)]
    public string SammelVtId { get; set; }
    [StringLength(4)]
    public string SchadenBetJaNein { get; set; }
    [StringLength(250)]
    public string Schlagwoerter { get; set; }
    [StringLength(15)]
    public string SchwebeZuVertrag { get; set; }
    public DateTime? SEPAEinzugsmandat { get; set; }
    [StringLength(35)]
    public string SEPAMandatsreferenz { get; set; }
    [StringLength(30)]
    public string SepaSddType { get; set; }
    public bool? Sicherungsschein { get; set; }
    [StringLength(15)]
    public string Sourceid { get; set; }
    public bool? SpartenberechnAufschub { get; set; }
    public bool? SpartenberechnungAus { get; set; }
    public decimal? SpartenCounter { get; set; }
    public DateTime? SperrdatumVUAbrechnung { get; set; }
    [StringLength(10)]
    public string StandNr { get; set; }
    public decimal? StatCharges { get; set; }
    public decimal? StatChargesBetrag { get; set; }
    [StringLength(50)]
    public string Statpolice { get; set; }
    public DateTime? StatpoliceDate { get; set; }
    [StringLength(50)]
    public string Statpraemie { get; set; }
    public DateTime? StatpraemieDate { get; set; }
    [Required]
    [StringLength(9)]
    public string Status { get; set; }
    [StringLength(60)]
    public string Statusgrund { get; set; }
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
    public decimal? ZPraemie { get; set; }
    public decimal? ZQuote { get; set; }
    public DateTime? Zugangsdatum { get; set; }
    public int? ZugangsdatumJjjj { get; set; }
    public int? ZugangsdatumJjjjmm { get; set; }
    [StringLength(6)]
    public string Zuordnung { get; set; }

    // Navigation properties
    public virtual Vertrag Vertrag { get; set; }
}
