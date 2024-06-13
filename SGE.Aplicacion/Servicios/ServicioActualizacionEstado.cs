namespace SGE.Aplicacion;
/*
Para llevar a cabo el cambio automático del estado de un expediente, se puede emplear la siguiente
estrategia: 

Desarrollar un servicio que, a partir del Id de un expediente, recupere la etiqueta de su último
trámite. Basándose en esta información y conforme a las especificaciones detalladas en este documento,
dicho servicio realizará el cambio de estado del expediente cuando sea necesario. Este servicio podrá ser
invocado por los casos de uso correspondientes después de agregar, modificar o eliminar un trámite.


Además, resultaría beneficioso desacoplar el servicio de la especificación que define qué cambio de estado
debe llevarse a cabo en función de la etiqueta del último trámite. Esta especificación podría ser
suministrada al servicio mediante la técnica de inyección de dependencias.
*/


public class ServicioActualizacionEstado : IServicioActualizacionEstado
{
  public void ActualizarEstadoExpediente(
    int idExpediente,
    ITramiteRepositorio repoTramites,
    IExpedienteRepositorio repoExp,
    /*DUDA => DIP de la especificación es así? Genera mucho pasaje de parametros en el caso de uso*/
    IEspecificacionCambioEstado especificacionCambioEstado
    )
  {

    // 1. Obtener etiqueta último Tramite
    var listaTramites = repoTramites.ConsultarTramitesAsociadosAlExp(idExpediente);
    if (listaTramites.Count != 0)
    {
      EtiquetaTramite etiquetaUltimoTramite = listaTramites.Last().Etiqueta;

      // 2. Obtener nuevo estado mediante la especificacion
      Expediente expediente = repoExp.GetExpedienteById(idExpediente);
    EstadoExpediente nuevoEstado = especificacionCambioEstado.CambiarDeEstado(etiquetaUltimoTramite, expediente.Estado);

    // 3. Modificar expediente con el nuevo estado
    if (expediente.Estado != nuevoEstado)
    {
      expediente.Estado = nuevoEstado;

        /* 
        El cambio automático de estado del expediente no quedará registrado en
        los campos de fecha y usuario modificador. Por eso no se utiliza el 
        caso de uso correspondiente a la modificación.
        */
        repoExp.ModificarExpediente(expediente);
    }
    }

  }
}

