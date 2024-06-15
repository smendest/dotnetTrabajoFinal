using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioTramitesTXT : ITramiteRepositorio
{
  public void AgregarTramite(Tramite tramite)
  {
    using var db = new RepoContext();
    // el Id será establecido por SQLite
    db.Add(tramite); // se agregará realmente con el db.SaveChanges()
    db.SaveChanges(); //actualiza la base de datos.
  }

  public void EliminarTramite(int id)
  {
    using var db = new RepoContext();
    var tramite = db.Tramites.Where(tr => tr.Id == id).SingleOrDefault();
    if (tramite != null)
    {
      db.Remove(tramite); //se borra realmente con el db.SaveChanges()
      db.SaveChanges(); //actualiza la base de datos.
    }
    else throw new RepositorioException($"El Trámite con id {id} no fue encontrado en el archivo");
  }

  public void ModificarTramite(Tramite tramiteModificado)
  {
    using var db = new RepoContext();
    var tramite = db.Tramites.Where(
      e => e.Id == tramiteModificado.Id).SingleOrDefault();
    if (tramite != null)
    {
      /* Se modifica el registro en memoria */
      tramite.Contenido = tramiteModificado.Contenido;
      tramite.Etiqueta = tramiteModificado.Etiqueta;
      tramite.FechaUltimaModif = tramiteModificado.FechaUltimaModif;
      tramite.UserId = tramiteModificado.UserId;

      db.SaveChanges(); //actualiza la base de datos.
    }
  }

  public List<Tramite> ConsultarPorEtiqueta(EtiquetaTramite etiquetaElegida)
  {
    using var db = new RepoContext();
    List<Tramite> tramites = db.Tramites.Where(tr => tr.Etiqueta == etiquetaElegida).ToList();
    return tramites;
  }

  public Tramite GetTramiteById(int id)
  {
    using var db = new RepoContext();
    var tramite = db.Tramites.Where(tr => tr.Id == id).SingleOrDefault();
    if (tramite == null)
      throw new RepositorioException($"El trámite con id {id} no fue encontrado en la base de datos");
    return tramite;
  }

}
