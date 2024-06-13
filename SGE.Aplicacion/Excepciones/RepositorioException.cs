namespace SGE.Aplicacion;

/* La excepción RepositorioException debe ser lanzada cuando la entidad que se intenta eliminar,
 modificar o acceder no existe en el repositorio correspondiente.
 */
public class RepositorioException : Exception
{
  public RepositorioException()
  { }
  public RepositorioException(string message)
  : base(message)
  { }
  public RepositorioException(string message,
  Exception inner) : base(message, inner) { }
}
