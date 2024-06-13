namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
  void AgregarExpediente(Expediente expediente);
  void EliminarExpediente(int id);
  void ModificarExpediente(Expediente expedienteModificado);
  List<Expediente> ListarExpedientes();
  Expediente GetExpedienteById(int id);
  List<Expediente> ConsultarTodos();

}
