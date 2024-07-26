using System.ComponentModel.DataAnnotations;

namespace Assfinet.Shared.Entities
{
    public class KundeKontakt
    {
        public int KundeId { get; set; }
        [StringLength(40)] public string? Bank1 { get; set; }
        [StringLength(40)] public string? Bank2 { get; set; }
        [StringLength(11)] public string? Bic1 { get; set; }
        [StringLength(11)] public string? Bic2 { get; set; }
        [StringLength(12)] public string? Blz1 { get; set; }
        [StringLength(12)] public string? Blz2 { get; set; }
        [StringLength(80)] public string? EmailGeschaeftlich { get; set; }
        [StringLength(80)] public string? EmailPrivat { get; set; }
        [StringLength(35)] public string? Fax { get; set; }
        [StringLength(34)] public string? Iban1 { get; set; }
        [StringLength(34)] public string? Iban2 { get; set; }
        [StringLength(15)] public string? Mobiltelefon { get; set; }
        [StringLength(12)] public string? Konto1 { get; set; }
        [StringLength(12)] public string? Konto2 { get; set; }
        [StringLength(100)] public string? Kontobezeichnung1 { get; set; }
        [StringLength(100)] public string? Kontobezeichnung2 { get; set; }
        [StringLength(40)] public string? Kontoinhaber1 { get; set; }
        [StringLength(40)] public string? Kontoinhaber2 { get; set; }
        [StringLength(200)] public string? Internet { get; set; }
        [StringLength(35)] public string? TelefonGeschaeftlich { get; set; }
        [StringLength(35)] public string? TelefonPrivat { get; set; }

        // Navigation properties
        public virtual Kunde? Kunde { get; set; }
    }
}