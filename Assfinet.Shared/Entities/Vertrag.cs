using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assfinet.Shared.Entities;

public class Vertrag
{
    public int Id { get; set; }
    public Guid AmsId { get; set; }
    [StringLength(40)]
    public string Amsidnr { get; set; }
    public DateTime? Bearbeitet { get; set; }
    [StringLength(20)]
    public string? Sparte { get; set; }
    [StringLength(60)]
    public string? Details { get; set; }
    [Required]
    [StringLength(40)]
    public string Key { get; set; }
    [StringLength(40)]
    public string? Vu { get; set; }
    public int VuNummer { get; set; }
    [StringLength(60)]
    public string? ComputedStatus { get; set; }
    public bool Dirty { get; set; }
    [StringLength(40)]
    public string? License { get; set; }
    public DateTime LastSynchronisation { get; private set; }
    [NotMapped]
    [JsonExtensionData]
    public IDictionary<string, JToken> AdditionalData { get; set; }
    public bool? Abbuchung { get; set; }
    public DateTime? AblaufDt { get; set; }

    // Navigation properties
    public virtual VertragFinanzen Finanzen { get; set; }
    public virtual VertragDetails VertragDetails { get; set; }
    public virtual VertragHistorie Historie { get; set; }
    public virtual VertragBank BankDetails { get; set; }
    public virtual Kunde Kunde { get; set; }
}
