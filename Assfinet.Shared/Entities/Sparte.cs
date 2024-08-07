using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assfinet.Shared.Entities;

public class Sparte
{
    public int Id { get; set; }

    [Required] public Guid AmsId { get; set; }

    public DateTimeOffset? Bearbeitet { get; set; }

    [Required] [StringLength(40)] public string Amsidnr { get; set; }

    [Required] [StringLength(40)] public string Key { get; set; }

    [Required] [StringLength(50)] public string Typ { get; set; }

    [NotMapped] [JsonExtensionData] public IDictionary<string, JToken> AdditionalData { get; set; }

    public bool Dirty { get; set; }

    [StringLength(40)] public string? License { get; set; }

    public DateTime? LastSynchronisation { get; set; }
    
    public virtual ICollection<SparteFields> SparteFields { get; set; }
}