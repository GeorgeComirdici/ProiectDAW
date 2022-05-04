using ProiectDAW.Models;
using Microsoft.EntityFrameworkCore;
namespace ProiectDAW.data
{
    public class ProiectDAWcontext : DbContext
    {
        public ProiectDAWcontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<detaliiAngajati> detaliiAngajatis { get; set; }
        public DbSet<departamente> departamentes { get; set; }
        public DbSet<proiecte> proiectes { get; set; }
        public DbSet<adreseAngajati> adreseAngajatis { get; set; }
        public DbSet<proiecteAngajati> proiecteAngajatis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-SMUEMVG;Initial Catalog=ProiectDAW2;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<adreseAngajati>(entity =>
            {
                entity.HasOne(x => x.Angajati)
                      .WithOne(x => x.Adresa)
                      .HasForeignKey<detaliiAngajati>(x => x.IdAngajat);
            });
            modelBuilder.Entity<detaliiAngajati>(entity =>
            {
                entity.HasOne(x => x.Departamente)
                      .WithMany(x => x.Angajati)
                      .HasForeignKey(x => x.IdDepartament);
            });
            
            modelBuilder.Entity<proiecteAngajati>(entity =>
            {
                entity.HasKey(x => x.ID);
                entity.HasOne(x => x.detaliiAngajati)
                      .WithMany(x => x.proiecteAngajati)
                      .HasForeignKey(x => x.IdAngajat);
                entity.HasOne(x => x.proiecte)
                      .WithMany(x => x.proiecteAngajati)
                      .HasForeignKey(x => x.IdProiect);
            });
        }
    }
}