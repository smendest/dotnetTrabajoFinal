using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioUsuario : IUsuarioRepositorio
{
  readonly string _nombreArch = "../SGE.Repositorios/usuarios.txt";
  static int s_ultimoId = 0;

  public RepositorioUsuario()
  {
    AssignUniqueId();
  }

  private void AssignUniqueId()
  {
    // Determinar el último Id utilizado en el archivo si existe
    if (File.Exists(_nombreArch))
    {
      using var sr = new StreamReader(_nombreArch);
      while (!sr.EndOfStream)
      {
        int id = int.Parse(sr.ReadLine() ?? "");
        // Actualizar el último Id utilizado si es mayor que el actual
        if (id > s_ultimoId)
        {
          s_ultimoId = id;
        }
        // Saltar las líneas de los campos del usuario
        sr.ReadLine();  // Nombre 
        sr.ReadLine();  // Apellido 
        sr.ReadLine();  // Email 
        sr.ReadLine();  // Password 
        sr.ReadLine();  // IsAdmin 
      }
    }
  }

  public void AltaDeUsuario(Usuario usuario)
  {
    usuario.Id = ++s_ultimoId;
    using var sw = new StreamWriter(_nombreArch, true);
    sw.WriteLine(usuario.Id);
    sw.WriteLine(usuario.Nombre);
    sw.WriteLine(usuario.Apellido);
    sw.WriteLine(usuario.Email);
    sw.WriteLine(usuario.Password); // TODO: Reemplazar por función hash
    sw.WriteLine(usuario.Id == 1 ? "true" : "false");
    // Permisos
  }

  public List<Usuario> ListarUsuarios()
  {
    var resultado = new List<Usuario>();
    using var sr = new StreamReader(_nombreArch);
    while (!sr.EndOfStream)
    {
      var usuario = LeerUsuarioDelRepo(sr);
      resultado.Add(usuario);
    }

    return resultado;
  }

  private static Usuario LeerUsuarioDelRepo(StreamReader sr, bool withoutId = false)
  {
    Usuario usuario = new Usuario();

    if (!withoutId)
      usuario.Id = int.Parse(sr.ReadLine() ?? "");
    usuario.Nombre = sr.ReadLine() ?? "";
    usuario.Apellido = sr.ReadLine() ?? "";
    usuario.Email = sr.ReadLine() ?? "";
    usuario.Password = sr.ReadLine() ?? "";
    usuario.IsAdmin = bool.Parse(sr.ReadLine() ?? "");

    return usuario;
  }

}