using Apartamentos.Modelo;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Apto> apartamentos { get; set; }
    public DbSet<Inquilino> inquilinos { get; set; }
    public DbSet<Personal> personales { get; set; }
    public DbSet<Contrato> contratos { get; set; }
    public DbSet<Mantenimiento> mantenimientos { get; set; }
    public DbSet<Pago> pagos { get; set; }
    public DbSet<Incidencia> incidencias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuraciones personalizadas (si es necesario)
        modelBuilder.Entity<Contrato>()
            .HasOne(c => c.apartamentos)
            .WithMany()
            .HasForeignKey(c => c.apartamentosID);
    }
}