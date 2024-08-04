using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assfinet.Shared.Entities;

public class DepSparte
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

    public DateTime LastSynchronisation { get; set; }

    [StringLength(150)] public string? DEP101 { get; set; }
    [StringLength(150)] public string? DEP111 { get; set; }
    [StringLength(150)] public string? DEP113 { get; set; }
    [StringLength(150)] public string? DEP115 { get; set; }
    [StringLength(150)] public string? DEP116 { get; set; }
    [StringLength(150)] public string? DEP119 { get; set; }
    [StringLength(150)] public string? DEP120 { get; set; }
    [StringLength(150)] public string? DEP122 { get; set; }
    [StringLength(150)] public string? DEP125 { get; set; }
    [StringLength(150)] public string? DEP126 { get; set; }
    [StringLength(150)] public string? DEP128 { get; set; }
    [StringLength(150)] public string? DEP131 { get; set; }
    [StringLength(150)] public string? DEP132 { get; set; }
    [StringLength(150)] public string? DEP134 { get; set; }
    [StringLength(150)] public string? DEP137 { get; set; }
    [StringLength(150)] public string? DEP138 { get; set; }
    [StringLength(150)] public string? DEP140 { get; set; }
    [StringLength(150)] public string? DEP143 { get; set; }
    [StringLength(150)] public string? DEP144 { get; set; }
    [StringLength(150)] public string? DEP146 { get; set; }
    [StringLength(150)] public string? DEP149 { get; set; }
    [StringLength(150)] public string? DEP150 { get; set; }
    [StringLength(150)] public string? DEP152 { get; set; }
    [StringLength(150)] public string? DEP155 { get; set; }
    [StringLength(150)] public string? DEP156 { get; set; }
    [StringLength(150)] public string? DEP158 { get; set; }
    [StringLength(150)] public string? DEP161 { get; set; }
    [StringLength(150)] public string? DEP162 { get; set; }
    [StringLength(150)] public string? DEP164 { get; set; }
    [StringLength(150)] public string? DEP167 { get; set; }
    [StringLength(150)] public string? DEP168 { get; set; }
    [StringLength(150)] public string? DEP170 { get; set; }
    [StringLength(150)] public string? DEP173 { get; set; }
    [StringLength(150)] public string? DEP174 { get; set; }
    [StringLength(150)] public string? DEP176 { get; set; }
    [StringLength(150)] public string? DEP178 { get; set; }
    [StringLength(150)] public string? DEP179 { get; set; }
    [StringLength(150)] public string? DEP180 { get; set; }
}