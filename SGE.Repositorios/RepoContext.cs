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

}

