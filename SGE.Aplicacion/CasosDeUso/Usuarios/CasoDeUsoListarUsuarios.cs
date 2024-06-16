namespace SGE.Aplicacion;

public class CasoDeUsoListarUsuarios(IUsuarioRepositorio repo, IServicioAutorizacion autorizacion)
{
  public List<Usuario> Ejecutar(int idUsuario)
  {
    // Verificacación de permisos del usuario.
    if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuariosListar))
      throw new AutorizacionException();
    else
      return repo.ConsultarTodos();
  }
}
