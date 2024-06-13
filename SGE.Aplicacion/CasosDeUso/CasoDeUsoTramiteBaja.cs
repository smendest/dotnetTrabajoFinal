namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(
  ITramiteRepositorio repoTramite,
  IExpedienteRepositorio repoExp,
  TramiteValidador validador,
  IServicioAutorizacion autorizacion,
  IServicioActualizacionEstado actualizacionEstado,
  IEspecificacionCambioEstado especificacionCambioEstado
  )
{
  public void Ejecutar(int idTramite, int userId)
  {
    if (!validador.ValidarUserId(userId, out string mensajeError))
    {
      string errMessage = mensajeError;
      throw new ValidacionException(errMessage);
    }
    // Verificacación de permisos del usuario.
    if (!autorizacion.PoseeElPermiso(userId, Permiso.TramiteBaja))
    {
      throw new AutorizacionException();
    }
    Tramite tramite = repoTramite.GetTramiteById(idTramite);  // Para pasarle el Expediente asociado al servicio de actualizacion de estado.
    repoTramite.EliminarTramite(idTramite);
    actualizacionEstado.ActualizarEstadoExpediente(tramite.ExpedienteId, repoTramite, repoExp, especificacionCambioEstado);

  }

}
