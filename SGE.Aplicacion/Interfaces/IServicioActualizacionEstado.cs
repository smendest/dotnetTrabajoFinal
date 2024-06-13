namespace SGE.Aplicacion;

public interface IServicioActualizacionEstado
{
  void ActualizarEstadoExpediente(
    int idExpediente,
    ITramiteRepositorio repoTramites,
    IExpedienteRepositorio repoExp,
    IEspecificacionCambioEstado especificacionCambioEstado
    );

}
