using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioUsuario : IUsuarioRepositorio
{
  public void AltaDeUsuario(Usuario usuario)
  {
    using var db = new RepoContext();
    // Hash de la contraseña
    usuario.Password = HashHelper.HashPassword(usuario.Password);
    // el Id será establecido por SQLite
    db.Add(usuario); // se agregará realmente con el db.SaveChanges()
    db.SaveChanges(); //actualiza la base de datos. SQlite establece el valor de usuario.Id
  }

  public bool EsPrimerUsuario()
  {
    using var db = new RepoContext();
    return !db.Usuarios.Any();
  }

  public void BajaDeUsuario(int id)
  {
    using var db = new RepoContext();
    var usuario = db.Usuarios.Where(exp => exp.Id == id).SingleOrDefault();
    if (usuario != null)
    {
      db.Remove(usuario); //se borra realmente con el db.SaveChanges()
      db.SaveChanges(); //actualiza la base de datos.
    }
    else throw new RepositorioException($"El usuario con id {id} no fue encontrado en la base de datos");
  }

  public void ModificarUsuario(Usuario uModificado)
  {
    using var db = new RepoContext();
    var usuario = db.Usuarios.Where(
      e => e.Id == uModificado.Id).SingleOrDefault();
    if (usuario != null)
    {
      /* Se modifica el registro en memoria */
      usuario.Nombre = uModificado.Nombre;
      usuario.Apellido = uModificado.Apellido;
      usuario.Email = uModificado.Email;
      usuario.Permisos = uModificado.Permisos;

      // Solo actualizar el hash si la contraseña ha cambiado
      if (usuario.Password != uModificado.Password)
      {
        usuario.Password = HashHelper.HashPassword(uModificado.Password);
      }
      db.SaveChanges(); //actualiza la base de datos.
    }
    else
    {
      throw new RepositorioException($"El usuario con id {uModificado.Id} no fue encontrado en la base de datos");
    }

  }

  public void AutenticarUsuario(int id, string password)
  {
    using var db = new RepoContext();
    Usuario usuario = GetUserById(id);
    if (usuario == null || !VerificarPassword(password, usuario.Password))
    {
      throw new RepositorioException("Email o contraseña incorrectos");
    }
  }

  public bool VerificarPassword(string passwordIngresada, string hashAlmacenado)
  {
    // Hashear la contraseña ingresada
    string hashIngresado = HashHelper.HashPassword(passwordIngresada);
    // Comparar el hash ingresado con el hash almacenado
    return hashIngresado == hashAlmacenado;
  }

  public List<Usuario> ConsultarTodos()
  {
    using var db = new RepoContext();
    return db.Usuarios.ToList();
  }

  public Usuario GetUserById(int id)
  {
    using var db = new RepoContext();
    // var usuario = db.usuarios.Include(value => value.usuariosAsociados).Where(exp => exp.Id == id).SingleOrDefault();
    var usuario = db.Usuarios.Where(u => u.Id == id).SingleOrDefault();
    if (usuario == null)
      throw new RepositorioException($"El usuario con id {id} no fue encontrado en la base de datos");

    return usuario;
  }

}