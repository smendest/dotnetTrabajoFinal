namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(
  ITramiteRepositorio repoTramite,
  TramiteValidador validador,
  IServicioAutorizacion autorizacion,
  IServicioActualizacionEstado actualizacionEstado
  )
{
  public void Ejecutar(Tramite tramiteModificado, int idUsuario)
  {
    if (!validador.ValidarUserId(idUsuario, out string mensajeError))
    {
      string errMessage = mensajeError;
      throw new ValidacionException(errMessage);
    }
    // Verificacación de permisos del usuario.
    if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteModificacion))
    {
      throw new AutorizacionException();
    }
    tramiteModificado.FechaUltimaModif = DateTime.Now;
    tramiteModificado.UserId = idUsuario;
    repoTramite.ModificarTramite(tramiteModificado);
    actualizacionEstado.ActualizarEstadoExpediente(tramiteModificado.ExpedienteId);

  }

}
