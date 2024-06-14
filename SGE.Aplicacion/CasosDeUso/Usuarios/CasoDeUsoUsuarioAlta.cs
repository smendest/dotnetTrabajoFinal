namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioAlta(IUsuarioRepositorio repo)
{
  public void Ejecutar(Usuario usuario)
  {
    // Todas las propiedades del usuario son definidas en la interfaz y vienen dentro del objeto usuario.
    repo.AltaDeUsuario(usuario);
  }
}

