using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assfinet.Shared.Entities
{
    public class ImoSparte
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

        [StringLength(150)] public string? IMO101 { get; set; }
        [StringLength(150)] public string? IMO102 { get; set; }
        [StringLength(150)] public string? IMO104 { get; set; }
        [StringLength(150)] public string? IMO105 { get; set; }
        [StringLength(150)] public string? IMO106 { get; set; }
        [StringLength(150)] public string? IMO109 { get; set; }
        [StringLength(150)] public string? IMO110 { get; set; }
        [StringLength(150)] public string? IMO114 { get; set; }
        [StringLength(150)] public string? IMO115 { get; set; }
        [StringLength(150)] public string? IMO116 { get; set; }
        [StringLength(150)] public string? IMO117 { get; set; }
        [StringLength(150)] public string? IMO118 { get; set; }
        [StringLength(150)] public string? IMO119 { get; set; }
        [StringLength(150)] public string? IMO121 { get; set; }
        [StringLength(150)] public string? IMO122 { get; set; }
        [StringLength(150)] public string? IMO123 { get; set; }
        [StringLength(150)] public string? IMO125 { get; set; }
        [StringLength(150)] public string? IMO126 { get; set; }
        [StringLength(150)] public string? IMO127 { get; set; }
        [StringLength(150)] public string? IMO128 { get; set; }
        [StringLength(150)] public string? IMO130 { get; set; }
        [StringLength(150)] public string? IMO131 { get; set; }
        [StringLength(150)] public string? IMO132 { get; set; }
    }
}