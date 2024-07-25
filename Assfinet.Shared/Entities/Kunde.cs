using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assfinet.Shared.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
    public string Amsidnr { get; set; } // Zwangsfeld

    // Navigation properties
    public virtual KundePersonenDetails PersonenDetails { get; set; }
    public virtual KundeFinanzen Finanzen { get; set; }
    public virtual KundeKontakt Kontakt { get; set; }
    public virtual ICollection<Vertrag> Vertraege { get; set; }
}