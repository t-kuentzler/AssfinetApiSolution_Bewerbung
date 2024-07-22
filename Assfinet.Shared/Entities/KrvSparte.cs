using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assfinet.Shared.Entities;

public class KrvSparte
{
    public int Id { get; set; }
    public Guid AmsId { get; set; }     
    public DateTimeOffset? Bearbeitet { get; set; }
    public string Amsidnr { get; set; }
    public string Key { get; set; } // Vater - Datensatz, also zugehöriger Vertrag.Amsidnr
    public string Typ { get; set; }
    [JsonExtensionData]
    public IDictionary<string, JToken> AdditionalData { get; set; }
    /// <summary>
    /// Gibt an ob dieser Datensatz lokal geändert und noch nicht von AMS bestätigt wurde
    /// </summary>
    public bool Dirty { get; set; } // automatisches Feld, soll nicht manuell gesetzt werden
    /// <summary>
    /// Die Lizenz der der Vertrag angehört
    /// </summary>
    public string License { get; set; }
    public DateTime LastSynchronisation { get; private set; }
    public string KRV101 { get; set; }
    public string KRV102 { get; set; }
    public string KRV103 { get; set; }
    public string KRV104 { get; set; }
    public string KRV105 { get; set; }
    public string KRV106 { get; set; }
    public string KRV108 { get; set; }
    public string KRV109 { get; set; }
    public string KRV110 { get; set; }
    public string KRV111 { get; set; }
    public string KRV112 { get; set; }
    public string KRV113 { get; set; }
    public string KRV114 { get; set; }
    public string KRV115 { get; set; }
    public string KRV116 { get; set; }
    public string KRV117 { get; set; }
    public string KRV118 { get; set; }
    public string KRV119 { get; set; }
    public string KRV120 { get; set; }
    public string KRV121 { get; set; }
    public string KRV122 { get; set; }
    public string KRV123 { get; set; }
    public string KRV124 { get; set; }
    public string KRV125 { get; set; }
    public string KRV126 { get; set; }
    public string KRV127 { get; set; }
    public string KRV128 { get; set; }
    public string KRV129 { get; set; }
    public string KRV130 { get; set; }
    public string KRV132 { get; set; }
    public string KRV134 { get; set; }
    public string KRV135 { get; set; }
    public string KRV136 { get; set; }
    public string KRV138 { get; set; }
    public string KRV141 { get; set; }
    public string KRV143 { get; set; }
    public string KRV145 { get; set; }
    public string KRV147 { get; set; }
    public string KRV149 { get; set; }
    public string KRV151 { get; set; }
    public string KRV153 { get; set; }
    public string KRV155 { get; set; }
    public string KRV156 { get; set; }
    public string KRV158 { get; set; }
    public string KRV159 { get; set; }
    public string KRV161 { get; set; }
    public string KRV162 { get; set; }
    public string KRV164 { get; set; }
    public string KRV165 { get; set; }
    public string KRV167 { get; set; }
    public string KRV168 { get; set; }
    public string KRV169 { get; set; }
    public string KRV171 { get; set; }
    public string KRV172 { get; set; }
    public string KRV173 { get; set; }
    public string KRV174 { get; set; }
    public string KRV204 { get; set; }
    public string KRV205 { get; set; }
    public string KRV206 { get; set; }
    public string KRV207 { get; set; }
    public string KRV209 { get; set; }
    public string KRV214 { get; set; }
    public string KRV215 { get; set; }
    public string KRV216 { get; set; }
    public string KRV217 { get; set; }
    public string KRV219 { get; set; }
    public string KRV229 { get; set; }
    public string KRV239 { get; set; }
    public string KRV249 { get; set; }
    public string KRV259 { get; set; }
    public string KRV260 { get; set; }
    public string KRV261 { get; set; }
    public string KRV262 { get; set; }
    public string KRV263 { get; set; }
    public string KRV264 { get; set; }
    public string KRV177 { get; set; }
    public string KRV178 { get; set; }
    public string KRV180 { get; set; }
    public string KRV181 { get; set; }
    public string KRV300 { get; set; }
    public string KRV301 { get; set; }
    public string KRV306 { get; set; }
    public string KRV307 { get; set; }
    public string KRV308 { get; set; }
    public string KRV309 { get; set; }
    public string KRV314 { get; set; }
    public string KRV315 { get; set; }
    public string KRV316 { get; set; }
    public string KRV317 { get; set; }
    public string KRV324 { get; set; }
    public string KRV325 { get; set; }
    public string KRV326 { get; set; }
    public string KRV327 { get; set; }
    public string KRV333 { get; set; }
    public string KRV334 { get; set; }
    public string KRV335 { get; set; }
    public string KRV336 { get; set; }
    public string KRV337 { get; set; }
    public string KRV343 { get; set; }
    public string KRV344 { get; set; }
    public string KRV345 { get; set; }
    public string KRV346 { get; set; }
    public string KRV347 { get; set; }
}