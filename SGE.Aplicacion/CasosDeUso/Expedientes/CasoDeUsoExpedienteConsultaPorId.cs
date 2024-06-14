namespace SGE.Aplicacion;
/*
Consulta de un expediente junto con todos sus trámites, utilizando el Id del expediente como referencia.
*/
public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repo, ITramiteRepositorio repoTramite)
{
  public Expediente Ejecutar(int idExpediente)
  {
    Expediente expediente = repo.GetExpedienteById(idExpediente);
    expediente.TramitesAsociados = repoTramite.ConsultarTramitesAsociadosAlExp(idExpediente);

    return expediente;
  }
}