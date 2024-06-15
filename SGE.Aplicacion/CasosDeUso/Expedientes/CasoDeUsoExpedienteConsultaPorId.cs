namespace SGE.Aplicacion;
/*
Consulta de un expediente junto con todos sus trámites, utilizando el Id del expediente como referencia.
*/
public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repo)
{
  public Expediente Ejecutar(int idExpediente)
  {
    Expediente expediente = repo.GetExpedienteById(idExpediente);

    return expediente;
  }
}