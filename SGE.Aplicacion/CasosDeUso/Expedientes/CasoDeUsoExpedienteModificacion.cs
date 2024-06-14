namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo, ExpedienteValidador validador, IServicioAutorizacion autorizacion)
{
  public void Ejecutar(Expediente expedienteModificado, int idUsuario)
  {
    if (!validador.ValidarUserId(idUsuario, out string mensajeError)
     && (!validador.ValidarCaratula(expedienteModificado, out string mensajeError2)))
    {
      throw new ValidacionException(mensajeError + ' ' + mensajeError2);
    }
    // Verificacación de permisos del usuario.
    if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteModificacion))
    {
      throw new AutorizacionException();
    }
    expedienteModificado.FechaUltimaModif = DateTime.Now;
    expedienteModificado.UserId = idUsuario;
    repo.ModificarExpediente(expedienteModificado);

  }
}