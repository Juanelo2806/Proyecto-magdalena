using Microsoft.EntityFrameworkCore;


namespace MGPRECISION.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Finca> Fincas { get; set; }
        public DbSet<Lote>  Lotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Finca>(s =>
            {
                s.Property(f => f.Nombre).HasMaxLength(200)
                .IsRequired();
                s.Property(f => f.Codigo)
                .HasColumnType("int").HasPrecision(5,0);
                s.Property(f => f.Codigo).IsRequired();

            });

            modelBuilder.Entity<Lote>(l =>
            {
                l.Property(s => s.Area)
               .HasColumnType("decimal(18,2)");
            });
            
            modelBuilder.Entity<Finca>().HasIndex( f => f.Codigo).IsUnique();
       
        }
    }
    
}
