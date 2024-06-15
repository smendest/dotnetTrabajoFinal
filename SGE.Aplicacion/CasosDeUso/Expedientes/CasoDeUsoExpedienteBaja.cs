namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repoExp, ITramiteRepositorio repoTramite, ExpedienteValidador validador, IServicioAutorizacion autorizacion)
{
  // DUDA: Debe recibir el expediente o solo el id???
  public void Ejecutar(int idExpediente, int idUsuario)
  {
    if (!validador.ValidarUserId(idUsuario, out string mensajeError))
    {
      throw new ValidacionException(mensajeError);
    }
    // Verificacación de permisos del usuario.
    if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteBaja))
    {
      throw new AutorizacionException();
    }
    repoExp.EliminarExpediente(idExpediente);
  }
}

