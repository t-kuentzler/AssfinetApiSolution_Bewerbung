using System.ComponentModel.DataAnnotations;

namespace Assfinet.Shared.Entities;

public class SparteFields
{
    public int Id { get; set; }

    [Required]
    public int SparteId { get; set; }

    [Required]
    [StringLength(50)]
    public string FieldName { get; set; }

    [StringLength(150)]
    public string? FieldValue { get; set; }

    public virtual Sparte Sparte { get; set; }
}