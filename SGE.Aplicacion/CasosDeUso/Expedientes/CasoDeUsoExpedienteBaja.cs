namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repoExp, ExpedienteValidador validador, IServicioAutorizacion autorizacion)
{
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

