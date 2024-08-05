using Assfinet.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assfinet.Shared
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<KundePersonenDetails> KundenPersonenDetails { get; set; }
        public DbSet<KundeFinanzen> KundenFinanzen { get; set; }
        public DbSet<KundeKontakt> KundenKontakte { get; set; }
        
        public DbSet<Vertrag> Vertraege { get; set; }
        public DbSet<VertragDetails> VertragDetails { get; set; }
        public DbSet<VertragHistorie> VertragHistorien { get; set; }
        public DbSet<VertragBank> VertragBanken { get; set; }
        
        public DbSet<KrvSparte> KrvSparten { get; set; }
        public DbSet<KrvSparte> DepSparten { get; set; }

        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = Environment.GetEnvironmentVariable("HANSMANN_ASSFINET_SCHATTENDATENBANK_CONNECTIONSTRING_TEST");

                if (!string.IsNullOrEmpty(connectionString))
                {
                    optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 23))); 
                }
                else
                {
                    throw new InvalidOperationException("Keine gültige Verbindungszeichenfolge in der Umgebungsvariablen gefunden.");
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kunde>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.AmsId).IsUnique();
            
                entity.HasOne(e => e.PersonenDetails)
                    .WithOne(pd => pd.Kunde)
                    .HasForeignKey<KundePersonenDetails>(pd => pd.KundeId);

                entity.HasOne(e => e.Finanzen)
                    .WithOne(f => f.Kunde)
                    .HasForeignKey<KundeFinanzen>(f => f.KundeId);

                entity.HasOne(e => e.Kontakt)
                    .WithOne(k => k.Kunde)
                    .HasForeignKey<KundeKontakt>(k => k.KundeId);
            });

            modelBuilder.Entity<KundePersonenDetails>(entity =>
            {
                entity.HasKey(e => e.KundeId);
            });

            modelBuilder.Entity<KundeFinanzen>(entity =>
            {
                entity.HasKey(e => e.KundeId);
            });

            modelBuilder.Entity<KundeKontakt>(entity =>
            {
                entity.HasKey(e => e.KundeId);
            });

            modelBuilder.Entity<Vertrag>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.AmsId).IsUnique();

                entity.HasOne(e => e.Finanzen)
                    .WithOne(f => f.Vertrag)
                    .HasForeignKey<VertragFinanzen>(f => f.VertragId);

                entity.HasOne(e => e.VertragDetails)
                    .WithOne(d => d.Vertrag)
                    .HasForeignKey<VertragDetails>(d => d.VertragId);

                entity.HasOne(e => e.Historie)
                    .WithOne(h => h.Vertrag)
                    .HasForeignKey<VertragHistorie>(h => h.VertragId);

                entity.HasOne(e => e.BankDetails)
                    .WithOne(b => b.Vertrag)
                    .HasForeignKey<VertragBank>(b => b.VertragId);

                entity.HasOne(e => e.Kunde)
                    .WithMany(k => k.Vertraege)
                    .HasForeignKey(e => e.Key)
                    .HasPrincipalKey(k => k.Amsidnr)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<VertragFinanzen>(entity =>
            {
                entity.HasKey(e => e.VertragId);
            });

            modelBuilder.Entity<VertragDetails>(entity =>
            {
                entity.HasKey(e => e.VertragId);
            });

            modelBuilder.Entity<VertragHistorie>(entity =>
            {
                entity.HasKey(e => e.VertragId);
            });

            modelBuilder.Entity<VertragBank>(entity =>
            {
                entity.HasKey(e => e.VertragId);
            });

            modelBuilder.Entity<KrvSparte>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.AmsId).IsUnique();

                entity.HasOne<Vertrag>()
                    .WithMany()
                    .HasForeignKey(e => e.Key)
                    .HasPrincipalKey(v => v.Amsidnr)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<DepSparte>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.AmsId).IsUnique();

                entity.HasOne<Vertrag>()
                    .WithMany()
                    .HasForeignKey(e => e.Key)
                    .HasPrincipalKey(v => v.Amsidnr)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<ImoSparte>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.AmsId).IsUnique();

                entity.HasOne<Vertrag>()
                    .WithMany()
                    .HasForeignKey(e => e.Key)
                    .HasPrincipalKey(v => v.Amsidnr)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
