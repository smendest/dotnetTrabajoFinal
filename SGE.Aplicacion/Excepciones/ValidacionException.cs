namespace SGE.Aplicacion;

// La excepción ValidacionException debe ser lanzada cuando una entidad no cumple con los requisitos exigidos y, por lo tanto, no supera la validación establecida.
public class ValidacionException : Exception
{
  public ValidacionException()
  { }
  public ValidacionException(string message)
  : base(message)
  { }
  public ValidacionException(string message,
  Exception inner) : base(message, inner) { }
}
