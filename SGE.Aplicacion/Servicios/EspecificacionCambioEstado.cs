namespace SGE.Aplicacion;

public class EspecificacionCambioEstado : IEspecificacionCambioEstado
{
  public EstadoExpediente CambiarDeEstado(EtiquetaTramite etiquetaUltimoTramite, EstadoExpediente estadoAnterior)
  {
    /*
      Cambio automático de estado de un Expediente

      Los trámites que provocan un cambio automático en el estado del expediente son los siguientes:

      * Cuando la etiqueta del último trámite es "Resolución", se produce un cambio automático al estado "Con resolución".
      * Cuando la etiqueta del último trámite es "Pase a estudio", se produce un cambio automático al estado "Para resolver".
      * Cuando la etiqueta del último trámite es "Pase al Archivo", se produce un cambio automático al estado "Finalizado".

    */

    switch (etiquetaUltimoTramite)
    {
      case EtiquetaTramite.Resolucion:
        return EstadoExpediente.ConResolucion;

      case EtiquetaTramite.PaseAEstudio:
        return EstadoExpediente.ParaResolver;

      case EtiquetaTramite.PaseAlArchivo:
        return EstadoExpediente.Finalizado;

      default:
        return estadoAnterior;
    }
  }
}
