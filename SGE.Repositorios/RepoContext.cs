namespace SGE.Repositorios;
using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;

public class RepoContext : DbContext
{
#nullable disable
  public DbSet<Expediente> Expedientes { get; set; }
  public DbSet<Tramite> Tramites { get; set; }
  public DbSet<Usuario> Usuarios { get; set; }
#nullable disable


  protected override void OnConfiguring(DbContextOptionsBuilder
      optionsBuilder)
  {
    optionsBuilder.UseSqlite("data source=../SGE.Repositorios/Repositorios.sqlite");
  }

  // protected override void OnModelCreating(ModelBuilder modelBuilder)
  // {
  //   modelBuilder.Entity<Expediente>()
  //       .HasMany(a => a.TramitesAsociados)
  //       .WithOne()
  //       .HasForeignKey(b => b.ExpedienteId)
  //       .OnDelete(DeleteBehavior.Cascade);

  //   modelBuilder.Entity<Usuario>()
  //       .HasMany(a => a.ExpedientesAsociados)
  //       .WithOne()
  //       .HasForeignKey(b => b.UserId)
  //       .OnDelete(DeleteBehavior.Cascade);


  //   modelBuilder.Entity<Usuario>()
  //       .HasMany(a => a.TramitesAsociados)
  //       .WithOne()
  //       .HasForeignKey(b => b.UserId)
  //       .OnDelete(DeleteBehavior.Cascade);


  //   base.OnModelCreating(modelBuilder);
  // }
}

