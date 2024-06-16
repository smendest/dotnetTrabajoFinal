namespace SGE.Aplicacion;

public interface IUsuarioRepositorio
{
  bool EsPrimerUsuario();
  void AltaDeUsuario(Usuario usuario);
  void BajaDeUsuario(int id);
  void ModificarUsuario(Usuario uModificado);
  List<Usuario> ConsultarTodos();
  Usuario GetUserById(int id);

}
