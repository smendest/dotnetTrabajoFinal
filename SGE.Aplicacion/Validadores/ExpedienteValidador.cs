namespace SGE.Aplicacion;

public class ExpedienteValidador
{
  // La carátula de un expediente no puede estar vacía
  // El id de usuario (en trámites y expedientes) debe ser un id válido (entero mayor que 0)
  public bool ValidarUserId(int userId, out string mensajeError)
  {
    mensajeError = "";
    if (userId <= 0)
    {
      mensajeError = "El ID de usuario debe ser un valor mayor que cero.\n";
    }
    return (mensajeError == "");
  }

  public bool ValidarCaratula(Expediente expediente, out string mensajeError)
  {
    mensajeError = "";
    if (string.IsNullOrWhiteSpace(expediente.Caratula))
    {
      mensajeError = "Carátula del expediente inválida.\n";
    }
    return (mensajeError == "");
  }
}
