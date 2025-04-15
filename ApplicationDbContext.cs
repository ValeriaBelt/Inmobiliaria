using Apartamentos.Modelo;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }



    public DbSet<Apto> apartamento { get; set; }
    public DbSet<Inquilino> inquilino { get; set; }
    public DbSet<Personal> personal { get; set; }
    public DbSet<Contrato> contrato { get; set; }
    public DbSet<Mantenimiento> mantenimiento { get; set; }
    public DbSet<Pago> pago { get; set; }
    public DbSet<Incidencia> incidencia { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuraciones personalizadas (si es necesario)
        modelBuilder.Entity<Contrato>()
            .HasOne(c => c.apartamento)
            .WithMany()
            .HasForeignKey(c => c.idapartamento);
    }

}