namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioMofificacion(IUsuarioRepositorio repo, IServicioAutorizacion autorizacion)
{
  public void Ejecutar(Usuario usuarioModificado, int idUsuarioActual)
  {
    // Verificacación de permisos del usuario.
    if (!autorizacion.PoseeElPermiso(idUsuarioActual, Permiso.UsuarioModificacion))
      throw new AutorizacionException();
    else
      repo.ModificarUsuario(usuarioModificado);
  }
}
