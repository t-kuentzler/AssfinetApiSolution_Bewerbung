using System.ComponentModel.DataAnnotations;

namespace Assfinet.Shared.Entities;

public class VertragBank
{
    public int VertragId { get; set; }
    [StringLength(11)]
    public string Bic { get; set; }
    [StringLength(8)]
    public string Blz { get; set; }
    [StringLength(34)]
    public string Iban { get; set; }
    [StringLength(12)]
    public string Konto { get; set; }
    [StringLength(50)]
    public string Kontobezeichnung { get; set; }

    // Navigation properties
    public virtual Vertrag Vertrag { get; set; }
}
