namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(
  ITramiteRepositorio repoTramite,
  IExpedienteRepositorio repoExp,
  TramiteValidador validador,
  IServicioAutorizacion autorizacion,
  IServicioActualizacionEstado actualizacionEstado,
  IEspecificacionCambioEstado especificacionCambioEstado
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
    repoTramite.ModificarTramite(tramiteModificado);
    actualizacionEstado.ActualizarEstadoExpediente(tramiteModificado.ExpedienteId, repoTramite, repoExp, especificacionCambioEstado);

  }

}
