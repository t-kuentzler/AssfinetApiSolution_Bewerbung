using System.ComponentModel.DataAnnotations;

namespace Assfinet.Shared.Entities;

public class VertragHistorie
{
    public int VertragId { get; set; }
    public DateTime? Historiendatum { get; set; }
    [StringLength(100)]
    public string? Historiengrund { get; set; }
    [StringLength(40)]
    public string? HistorieZuVertrag { get; set; }
    public decimal? HonorarVm1 { get; set; }
    public decimal? HonorarVm10 { get; set; }
    public decimal? HonorarVm2 { get; set; }
    public decimal? HonorarVm3 { get; set; }
    public decimal? HonorarVm4 { get; set; }
    public decimal? HonorarVm5 { get; set; }
    public decimal? HonorarVm6 { get; set; }
    public decimal? HonorarVm7 { get; set; }
    public decimal? HonorarVm8 { get; set; }
    public decimal? HonorarVm9 { get; set; }
    [StringLength(15)]
    public string? Hpvahb { get; set; }
    public bool? HpvGruppe { get; set; }

    // Navigation properties
    public virtual Vertrag Vertrag { get; set; }
}
