using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assfinet.Shared.Entities
{
    public class Kunde
    {
        public int Id { get; set; }
        public Guid AmsId { get; set; }
        public DateTime? Bearbeitet { get; set; }
        public bool Dirty { get; set; }
        public string License { get; set; }
        public DateTime LastSynchronisation { get; private set; }
        
        [NotMapped]
        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }

        [StringLength(40)]
        public string Amsidnr { get; set; }
        [StringLength(200)]
        public string Kundenname { get; set; }
        [StringLength(200)]
        public string KundennamePhonetisch { get; set; }
        [StringLength(200)]
        public string Kundentyp { get; set; }
        [StringLength(20)]
        public string Kundenverbindung { get; set; }
        public DateTime? KundeSeit { get; set; }
        [StringLength(50)]
        public string LageBetriebsgrundstuecks { get; set; }
        [StringLength(3)]
        public string Land { get; set; }
        [StringLength(50)]
        public string Landesname { get; set; }
        public DateTime? LetzterBesuch { get; set; }
        public decimal? LohnGehaltssumme { get; set; }
        public DateTime? MahnstopBis { get; set; }
        public DateTime? MaklervertragBis { get; set; }
        public DateTime? MaklervertragDatum { get; set; }
        [StringLength(50)]
        public string Mandant { get; set; }
        [StringLength(40)]
        public string MandantAmsidnr { get; set; }
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
        [StringLength(15)]
        public string Partner { get; set; }
        [StringLength(30)]
        public string PAusbildung { get; set; }
        public DateTime? PAustrittVorag { get; set; }
        public bool? PBefristvt { get; set; }
        public DateTime? PBefristvtBis { get; set; }
        [StringLength(20)]
        public string PBeschaeftignungsverhaeltnis { get; set; }
        [StringLength(100)]
        public string PBildung { get; set; }
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
        public bool? PGehaltBbgKranken { get; set; }
        public bool? PGehaltBbgRente { get; set; }
        [StringLength(7)]
        public string Plz { get; set; }
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

        // Navigation properties
        public virtual KundePersonenDetails PersonenDetails { get; set; }
        public virtual KundeFinanzen Finanzen { get; set; }
        public virtual KundeKontakt Kontakt { get; set; }
        public virtual ICollection<Vertrag> Vertraege { get; set; }
    }
}
