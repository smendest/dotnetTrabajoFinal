namespace SGE.Aplicacion;

// La excepción AutorizacionException debe ser lanzada cuando un usuario intenta realizar una operación para la cual no tiene los permisos necesarios.
public class AutorizacionException : Exception
{
  static string DefaultMessage = "El usuario no posee los permisos necesarios para realizar esta operación.";
  public AutorizacionException() : base(DefaultMessage)
  { }
  public AutorizacionException(string message)
  : base(message)
  { }
  public AutorizacionException(string message,
  Exception inner) : base(message, inner) { }

}
