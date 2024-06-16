namespace SGE.Aplicacion;
public class ServicioAutorizacion(IUsuarioRepositorio RepoUsuarios) : IServicioAutorizacion
{
  public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
  {
    // 1. Obtener usuario
    var usuario = RepoUsuarios.GetUserById(IdUsuario);
    // 2. Buscar si el permiso se encuentra en la lista de permisos que posee el usuario
    return usuario.Permisos.Contains(permiso);
  }
}