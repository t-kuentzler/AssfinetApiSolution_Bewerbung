namespace Assfinet.Shared.Entities;

public class VertragFinanzen
{
    public int VertragId { get; set; }
    public decimal? ApBetrag { get; set; }
    public DateTime? ApBuchungsdatum { get; set; }
    public decimal? BwSumme { get; set; }
    public decimal? Bwsummezv { get; set; }
    public decimal? DifferenzCourtage { get; set; }
    public decimal? DifferenzCourtageBetrag { get; set; }
    public decimal? EffektivcourtageProzent { get; set; }
    public decimal? PraemieNetto { get; set; }
    public decimal? ProgrammCourtage { get; set; }
    public decimal? ProgrammCourtageBetrag { get; set; }
    public decimal? Jahrespraemie { get; set; }
    public decimal? Jahressteuerbetrag { get; set; }
    public decimal? Steuer { get; set; }
    public decimal? SteuerZw { get; set; }
    public decimal? Zuschlagbetrag { get; set; }
    public decimal? ZuschlagbetragZw { get; set; }

    // Navigation properties
    public virtual Vertrag Vertrag { get; set; }
}
