using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assfinet.Shared.Models;

public partial class VertragSparteModel
{
    public Guid Id { get; set; }
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
}