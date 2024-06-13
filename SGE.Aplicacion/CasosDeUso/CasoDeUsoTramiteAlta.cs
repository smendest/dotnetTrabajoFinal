namespace SGE.Aplicacion;

/*DUDA => DIP de la especificación es así? Genera mucho pasaje de parametros en el caso de uso*/
public class CasoDeUsoTramiteAlta(
  ITramiteRepositorio repoTramite,
  TramiteValidador validador,
  IServicioAutorizacion autorizacion,
  IServicioActualizacionEstado actualizacionEstado
  )

{
  public void Ejecutar(Tramite tramite, int userId)
  {
    if (!validador.ValidarUserId(userId, out string mensajeError) && !validador.ValidarContenido(tramite, out string mensajeError2))
    {
      string errMessage = mensajeError + ' ' + mensajeError2;
      throw new ValidacionException(errMessage);
    }
    // Verificación de permisos del usuario.
    if (!autorizacion.PoseeElPermiso(userId, Permiso.TramiteAlta))
    {
      throw new AutorizacionException();
    }
    tramite.Etiqueta = EtiquetaTramite.EscritoPresentado;
    tramite.FechaCreacion = DateTime.Now;
    tramite.FechaUltimaModif = tramite.FechaCreacion;
    tramite.UserId = userId;
    repoTramite.AgregarTramite(tramite);
    actualizacionEstado.ActualizarEstadoExpediente(tramite.ExpedienteId);
  }

}
