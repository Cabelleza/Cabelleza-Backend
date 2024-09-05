using Cabelleza.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Cabelleza.Dados;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Salao> Salao { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Salao>()
            .Property(s => s.NomeSalao)
            .HasMaxLength(100)
            .IsRequired();
    }
}
