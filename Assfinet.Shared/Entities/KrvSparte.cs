using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assfinet.Shared.Entities;

public class KrvSparte
{
    public int Id { get; set; }
    public Guid AmsId { get; set; }
    public DateTimeOffset? Bearbeitet { get; set; }

    [StringLength(40)] public string Amsidnr { get; set; }

    [StringLength(40)] public string Key { get; set; } // Vater - Datensatz, also zugehöriger Vertrag.Amsidnr

    [Required] [StringLength(50)] public string Typ { get; set; }

    [JsonExtensionData] public IDictionary<string, JToken> AdditionalData { get; set; }

    /// <summary>
    /// Gibt an ob dieser Datensatz lokal geändert und noch nicht von AMS bestätigt wurde
    /// </summary>
    public bool Dirty { get; set; } // automatisches Feld, soll nicht manuell gesetzt werden

    /// <summary>
    /// Die Lizenz der der Vertrag angehört
    /// </summary>

    [StringLength(40)]
    public string License { get; set; }

    public DateTime LastSynchronisation { get; private set; }

    [StringLength(80)] public string KRV101 { get; set; }

    [StringLength(80)] public string KRV102 { get; set; }

    [StringLength(80)] public string KRV103 { get; set; }

    [StringLength(80)] public string KRV104 { get; set; }

    [StringLength(80)] public string KRV105 { get; set; }

    [StringLength(80)] public string KRV106 { get; set; }

    [StringLength(80)] public string KRV108 { get; set; }

    [StringLength(80)] public string KRV109 { get; set; }

    [StringLength(80)] public string KRV110 { get; set; }

    [StringLength(80)] public string KRV111 { get; set; }

    [StringLength(80)] public string KRV112 { get; set; }

    [StringLength(80)] public string KRV113 { get; set; }

    [StringLength(80)] public string KRV114 { get; set; }

    [StringLength(80)] public string KRV115 { get; set; }

    [StringLength(80)] public string KRV116 { get; set; }

    [StringLength(80)] public string KRV117 { get; set; }

    [StringLength(80)] public string KRV118 { get; set; }

    [StringLength(80)] public string KRV119 { get; set; }

    [StringLength(80)] public string KRV120 { get; set; }

    [StringLength(80)] public string KRV121 { get; set; }

    [StringLength(80)] public string KRV122 { get; set; }

    [StringLength(80)] public string KRV123 { get; set; }

    [StringLength(80)] public string KRV124 { get; set; }

    [StringLength(80)] public string KRV125 { get; set; }

    [StringLength(80)] public string KRV126 { get; set; }

    [StringLength(80)] public string KRV127 { get; set; }

    [StringLength(80)] public string KRV128 { get; set; }

    [StringLength(80)] public string KRV129 { get; set; }

    [StringLength(80)] public string KRV130 { get; set; }

    [StringLength(80)] public string KRV132 { get; set; }

    [StringLength(80)] public string KRV134 { get; set; }

    [StringLength(80)] public string KRV135 { get; set; }

    [StringLength(80)] public string KRV136 { get; set; }

    [StringLength(80)] public string KRV138 { get; set; }

    [StringLength(80)] public string KRV141 { get; set; }

    [StringLength(80)] public string KRV143 { get; set; }

    [StringLength(80)] public string KRV145 { get; set; }

    [StringLength(80)] public string KRV147 { get; set; }

    [StringLength(80)] public string KRV149 { get; set; }

    [StringLength(80)] public string KRV151 { get; set; }

    [StringLength(80)] public string KRV153 { get; set; }

    [StringLength(80)] public string KRV155 { get; set; }

    [StringLength(80)] public string KRV156 { get; set; }

    [StringLength(80)] public string KRV158 { get; set; }

    [StringLength(80)] public string KRV159 { get; set; }

    [StringLength(80)] public string KRV161 { get; set; }

    [StringLength(80)] public string KRV162 { get; set; }

    [StringLength(80)] public string KRV164 { get; set; }

    [StringLength(80)] public string KRV165 { get; set; }

    [StringLength(80)] public string KRV167 { get; set; }

    [StringLength(80)] public string KRV168 { get; set; }

    [StringLength(80)] public string KRV169 { get; set; }

    [StringLength(80)] public string KRV171 { get; set; }

    [StringLength(80)] public string KRV172 { get; set; }

    [StringLength(80)] public string KRV173 { get; set; }

    [StringLength(80)] public string KRV174 { get; set; }

    [StringLength(80)] public string KRV204 { get; set; }

    [StringLength(80)] public string KRV205 { get; set; }

    [StringLength(80)] public string KRV206 { get; set; }

    [StringLength(80)] public string KRV207 { get; set; }

    [StringLength(80)] public string KRV209 { get; set; }

    [StringLength(80)] public string KRV214 { get; set; }

    [StringLength(80)] public string KRV215 { get; set; }

    [StringLength(80)] public string KRV216 { get; set; }

    [StringLength(80)] public string KRV217 { get; set; }

    [StringLength(80)] public string KRV219 { get; set; }

    [StringLength(80)] public string KRV229 { get; set; }

    [StringLength(80)] public string KRV239 { get; set; }

    [StringLength(80)] public string KRV249 { get; set; }

    [StringLength(80)] public string KRV259 { get; set; }

    [StringLength(80)] public string KRV260 { get; set; }

    [StringLength(80)] public string KRV261 { get; set; }

    [StringLength(80)] public string KRV262 { get; set; }

    [StringLength(80)] public string KRV263 { get; set; }

    [StringLength(80)] public string KRV264 { get; set; }

    [StringLength(80)] public string KRV177 { get; set; }

    [StringLength(80)] public string KRV178 { get; set; }

    [StringLength(80)] public string KRV180 { get; set; }

    [StringLength(80)] public string KRV181 { get; set; }

    [StringLength(80)] public string KRV300 { get; set; }

    [StringLength(80)] public string KRV301 { get; set; }

    [StringLength(80)] public string KRV306 { get; set; }

    [StringLength(80)] public string KRV307 { get; set; }

    [StringLength(80)] public string KRV308 { get; set; }

    [StringLength(80)] public string KRV309 { get; set; }

    [StringLength(80)] public string KRV314 { get; set; }

    [StringLength(80)] public string KRV315 { get; set; }

    [StringLength(80)] public string KRV316 { get; set; }

    [StringLength(80)] public string KRV317 { get; set; }

    [StringLength(80)] public string KRV324 { get; set; }

    [StringLength(80)] public string KRV325 { get; set; }

    [StringLength(80)] public string KRV326 { get; set; }

    [StringLength(80)] public string KRV327 { get; set; }

    [StringLength(80)] public string KRV333 { get; set; }

    [StringLength(80)] public string KRV334 { get; set; }

    [StringLength(80)] public string KRV335 { get; set; }

    [StringLength(80)] public string KRV336 { get; set; }

    [StringLength(80)] public string KRV337 { get; set; }

    [StringLength(80)] public string KRV343 { get; set; }

    [StringLength(80)] public string KRV344 { get; set; }

    [StringLength(80)] public string KRV345 { get; set; }

    [StringLength(80)] public string KRV346 { get; set; }

    [StringLength(80)] public string KRV347 { get; set; }
}