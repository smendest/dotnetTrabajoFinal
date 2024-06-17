namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repo, IServicioAutorizacion autorizacion)
{
  public void Ejecutar(Usuario usuarioModificado, int idUsuarioActual)
  {
    // Verificacación de permisos del usuario.
    if (autorizacion.PoseeElPermiso(idUsuarioActual, Permiso.UsuarioModificacion) || (usuarioModificado.Id == idUsuarioActual))
      repo.ModificarUsuario(usuarioModificado);
    else
      throw new AutorizacionException();
  }
}
