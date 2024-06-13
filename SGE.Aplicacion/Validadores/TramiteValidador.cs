namespace SGE.Aplicacion;

public class TramiteValidador
{
  // El contenido de un trámite no puede estar vacío
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

  public bool ValidarContenido(Tramite tramite, out string mensajeError)
  {
    mensajeError = "";
    if (string.IsNullOrWhiteSpace(tramite.Contenido))
    {
      mensajeError = "El contenido del trámite está vacío.\n";
    }
    return (mensajeError == "");
  }

}
