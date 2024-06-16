namespace SGE.Consola;
using SGE.Aplicacion;
using SGE.Repositorios;


public class AccionesUsuario
{
  static IUsuarioRepositorio RepoUsuarios { get; } = new RepositorioUsuario();
  static IServicioAutorizacion Autorizacion { get; } = new ServicioAutorizacion(RepoUsuarios);

  public static void CrearNuevo()
  {
    try
    {
      var crearNuevoUsuario = new CasoDeUsoUsuarioAlta(RepoUsuarios);
      Console.WriteLine(">>>> ALTA DE USUARIO <<<<");
      Usuario nuevoUsuario = new Usuario();
      IngresarUsuarioPorTeclado(nuevoUsuario);
      crearNuevoUsuario.Ejecutar(nuevoUsuario);
      SuccesLog();
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
  }

  public static void Eliminar(int IdUsuarioActual)
  {
    try
    {
      var eliminarUsuario = new CasoDeUsoUsuarioBaja(RepoUsuarios, Autorizacion);
      Console.WriteLine(">>>> BAJA DE USUARIO <<<<");
      Console.WriteLine("Ingrese el id de usuario que desea eliminar: ");
      int idUsuarioAEliminar = int.Parse(Console.ReadLine() ?? "0");
      eliminarUsuario.Ejecutar(idUsuarioAEliminar, IdUsuarioActual);
      SuccesLog();
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
  }

  public static void Modificar(int idUsuarioActual)
  {
    try
    {
      var modificarUsuario = new CasoDeUsoUsuarioModificacion(RepoUsuarios, Autorizacion);

      Console.WriteLine("Ingrese el id del usuario que desea modificar: ");
      int idUsuarioAModificar = int.Parse(Console.ReadLine() ?? "0");

      Usuario usuario = RepoUsuarios.GetUserById(idUsuarioAModificar);

      Console.WriteLine("El usuario que desea modificar es el siguiente:");
      Console.WriteLine(usuario);
      Console.WriteLine();
      Usuario usuarioModificado = IngresarUsuarioPorTeclado(usuario);
      // TODO: Mostrar los permisos existentes
      EditarPermisos(usuario.Permisos);
      modificarUsuario.Ejecutar(usuarioModificado, idUsuarioActual);
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
  }

  private static Usuario IngresarUsuarioPorTeclado(Usuario usuario)
  {
    Console.Write("Ingrese nombre: ");
    usuario.Nombre = Console.ReadLine() ?? "";
    Console.Write("Ingrese apellido: ");
    usuario.Apellido = Console.ReadLine() ?? "";
    Console.Write("Ingrese correo electrónico: ");
    usuario.Email = Console.ReadLine() ?? "";
    Console.Write("Ingrese correo contraseña: ");
    usuario.Password = Console.ReadLine() ?? "";
    return usuario;

  }

  private static void EditarPermisos(List<Permiso> permisosExistentes)
  {
    Console.WriteLine("\nEditar permisos de usuario:");
    Console.WriteLine("- AGREGAR Permiso: Ingrese el número de opción POSITIVO (Ej: 5) del permiso que deseada agregar (de a uno por vez): ");
    Console.WriteLine("- QUITAR Permiso: Ingrese el número de opción NEGATIVO (Ej: -5) del permiso que deseada quitar (de a uno por vez): ");
    Console.WriteLine();
    Console.WriteLine("0) Ninguno");
    Console.WriteLine("1) ExpedienteAlta");
    Console.WriteLine("2) ExpedienteBaja");
    Console.WriteLine("3) ExpedienteModificacion");
    Console.WriteLine("4) TramiteAlta");
    Console.WriteLine("5) TramiteBaja");
    Console.WriteLine("6) TramiteModificacion");
    Console.WriteLine("7) UsuarioAlta");
    Console.WriteLine("8) UsuarioBaja");
    Console.WriteLine("9) UsuarioModificacion");
    Console.WriteLine("10) UsuariosListar");

    int option = int.Parse(Console.ReadLine() ?? "0");
    switch (option)
    {
      case 0:
        Console.WriteLine("No se agregó ningún permiso al usuario");
        break;
      case 1:
        permisosExistentes.Add(Permiso.ExpedienteAlta);
        break;
      case -1:
        permisosExistentes.Remove(Permiso.ExpedienteAlta);
        break;
      case 2:
        permisosExistentes.Add(Permiso.ExpedienteBaja);
        break;
      case -2:
        permisosExistentes.Remove(Permiso.ExpedienteBaja);
        break;
      case 3:
        permisosExistentes.Add(Permiso.ExpedienteModificacion);
        break;
      case -3:
        permisosExistentes.Remove(Permiso.ExpedienteModificacion);
        break;
      case 4:
        permisosExistentes.Add(Permiso.TramiteAlta);
        break;
      case -4:
        permisosExistentes.Remove(Permiso.TramiteAlta);
        break;
      case 5:
        permisosExistentes.Add(Permiso.TramiteBaja);
        break;
      case -5:
        permisosExistentes.Remove(Permiso.TramiteBaja);
        break;
      case 6:
        permisosExistentes.Add(Permiso.TramiteModificacion);
        break;
      case -6:
        permisosExistentes.Remove(Permiso.TramiteModificacion);
        break;
      case 7:
        permisosExistentes.Add(Permiso.UsuarioAlta);
        break;
      case -7:
        permisosExistentes.Remove(Permiso.UsuarioAlta);
        break;
      case 8:
        permisosExistentes.Add(Permiso.UsuarioBaja);
        break;
      case -8:
        permisosExistentes.Remove(Permiso.UsuarioBaja);
        break;
      case 9:
        permisosExistentes.Add(Permiso.UsuarioModificacion);
        break;
      case -9:
        permisosExistentes.Remove(Permiso.UsuarioModificacion);
        break;
      case 10:
        permisosExistentes.Add(Permiso.UsuariosListar);
        break;
      case -10:
        permisosExistentes.Remove(Permiso.UsuariosListar);
        break;

      default:
        throw new Exception("Opción de etiqueta incorrecta");
    }
  }


  public static void ListarTodos(int idUsuario)
  {
    try
    {
      var consultarTodos = new CasoDeUsoListarUsuarios(RepoUsuarios, Autorizacion);
      List<Usuario> listadoCompleto = consultarTodos.Ejecutar(idUsuario);

      foreach (Usuario usuario in listadoCompleto)
      {
        Console.WriteLine(usuario);
      }
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
  }

  private static void SuccesLog()
  {
    Console.WriteLine("\n==== Tarea realizada con éxito ====\n");
  }
}
