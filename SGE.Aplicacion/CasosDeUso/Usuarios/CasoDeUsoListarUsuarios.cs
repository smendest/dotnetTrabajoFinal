namespace SGE.Aplicacion;

public class CasoDeUsoListarUsuarios(IUsuarioRepositorio repo, IServicioAutorizacion autorizacion)
{
  public List<Usuario> Ejecutar(int idUsuario)
  {
    // Verificacación de permisos del usuario.
    if (autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuariosListar))
      return repo.ConsultarTodos();
    else
      throw new AutorizacionException();
  }
}
