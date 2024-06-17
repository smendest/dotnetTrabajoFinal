namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioAutenticar(IUsuarioRepositorio repo)
{
  public void Ejecutar(string email, string password, out int idUsuario)
  {
    repo.AutenticarUsuario(email, password, out idUsuario);
  }
}
