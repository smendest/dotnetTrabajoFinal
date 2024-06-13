namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, ExpedienteValidador validador, IServicioAutorizacion autorizacion)
{
  public void Ejecutar(Expediente expediente, int idUsuario)
  {
    if (!validador.ValidarUserId(idUsuario, out string mensajeError) && !validador.ValidarCaratula(expediente, out string mensajeError2))
    {
      string errMessage = mensajeError + ' ' + mensajeError2;
      throw new ValidacionException(errMessage);
    }
    // Verificacación de permisos del usuario.
    if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta))
    {
      throw new AutorizacionException();
    }
    expediente.FechaCreacion = DateTime.Now;
    expediente.FechaUltimaModif = expediente.FechaCreacion;
    expediente.Estado = EstadoExpediente.RecienIniciado;
    expediente.UserId = idUsuario;
    repo.AgregarExpediente(expediente);
  }
}

