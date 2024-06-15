using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioExpedientes : IExpedienteRepositorio
{
  public void AgregarExpediente(Expediente expediente)
  {
    using var db = new RepoContext();
    // el Id será establecido por SQLite
    db.Add(expediente); // se agregará realmente con el db.SaveChanges()
    db.SaveChanges(); //actualiza la base de datos. SQlite establece el valor de expediente.Id
  }

  public void EliminarExpediente(int id)
  {
    using var db = new RepoContext();
    var expediente = db.Expedientes.Where(exp => exp.Id == id).SingleOrDefault();
    if (expediente != null)
    {
      db.Remove(expediente); //se borra realmente con el db.SaveChanges()
      db.SaveChanges(); //actualiza la base de datos.
    }
    else throw new RepositorioException($"El Expediente con id {id} no fue encontrado en la base de datos");
  }

  public void ModificarExpediente(Expediente expModificado)
  {
    using var db = new RepoContext();
    var expediente = db.Expedientes.Where(
      e => e.Id == expModificado.Id).SingleOrDefault();
    if (expediente != null)
    {
      /* Se modifica el registro en memoria */
      expediente.Caratula = expModificado.Caratula;
      expediente.FechaUltimaModif = expModificado.FechaUltimaModif;
      expediente.Estado = expModificado.Estado;  // Para el cambio automático de estado
      expediente.UserId = expModificado.UserId;

      db.SaveChanges(); //actualiza la base de datos.
    }
    else
    {
      throw new RepositorioException($"El Expediente con id {expModificado.Id} no fue encontrado en la base de datos");
    }

  }

  /* Devuelve el expediente con sus trámites asociados */
  public Expediente GetExpedienteById(int id)
  {
    using var db = new RepoContext();
    var expediente = db.Expedientes.Include(value => value.TramitesAsociados).Where(exp => exp.Id == id).SingleOrDefault();
    if (expediente == null)
      throw new RepositorioException($"El Expediente con id {id} no fue encontrado en la base de datos");

    return expediente;
  }

  public List<Expediente> ConsultarTodos()
  {
    using var db = new RepoContext();
    return db.Expedientes.ToList();
  }

}