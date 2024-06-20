namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioConsultaPorId(
  IUsuarioRepositorio repoUsuario
  )
{
  public Usuario Ejecutar(int idUsuario)
  {

    return repoUsuario.GetUserById(idUsuario);

  }

}
