namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio repo)
{
  public List<Expediente> Ejecutar()
  {
    return repo.ListarExpedientes();
  }
}
