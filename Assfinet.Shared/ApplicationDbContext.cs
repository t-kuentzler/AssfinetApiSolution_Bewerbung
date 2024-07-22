using Assfinet.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assfinet.Shared;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSet für Kunden
    public DbSet<Kunde> Kunden { get; set; }

    // DbSet für Verträge
    public DbSet<Vertrag> Vertraege { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Konfiguration für Kunde
        modelBuilder.Entity<Kunde>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.AmsId).IsUnique();
        });

        // Konfiguration für Vertrag
        modelBuilder.Entity<Vertrag>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Key).IsUnique();

            // Ein Vertrag gehört zu einem Kunden, basierend auf Key und AmsId
            entity.HasOne(e => e.Kunde)
                .WithMany(k => k.Vertraege)
                .HasForeignKey(e => e.Key)
                .HasPrincipalKey(k => k.AmsId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}