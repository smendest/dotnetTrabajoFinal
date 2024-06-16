namespace SGE.Aplicacion;

public interface IUsuarioRepositorio
{
  void AltaDeUsuario(Usuario usuario);
  void BajaDeUsuario(int id);
  void ModificarUsuario(Usuario uModificado);
  List<Usuario> ConsultarTodos();
  public Usuario GetUserById(int id);

}
