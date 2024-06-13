namespace SGE.Aplicacion;

public interface IEspecificacionCambioEstado
{
  EstadoExpediente CambiarDeEstado(EtiquetaTramite etiquetaUltimoTramite, EstadoExpediente estadoAnterior);
}
