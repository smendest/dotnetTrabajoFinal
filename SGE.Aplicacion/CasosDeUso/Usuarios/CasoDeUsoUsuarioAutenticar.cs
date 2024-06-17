namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioAutenticar(IUsuarioRepositorio repo)
{
  public void Ejecutar(int idUsuario, string password)
  {
    repo.AutenticarUsuario(idUsuario, password);
  }
}
