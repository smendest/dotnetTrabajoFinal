namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioAlta(IUsuarioRepositorio repo)
{
  /* Todas las propiedades del usuario son definidas en la interfaz y vienen dentro del objeto usuario.*/
  public void Ejecutar(Usuario usuario)
  {
    // Nos aseguramos que si el usuario no es Admin tenga solo permisos de lectura:
    if (repo.EsPrimerUsuario())
    {
      // Le asignamos todos los permisos al administrador
      usuario.Permisos.Add(Permiso.ExpedienteAlta);
      usuario.Permisos.Add(Permiso.ExpedienteBaja);
      usuario.Permisos.Add(Permiso.ExpedienteModificacion);
      usuario.Permisos.Add(Permiso.TramiteAlta);
      usuario.Permisos.Add(Permiso.TramiteBaja);
      usuario.Permisos.Add(Permiso.TramiteModificacion);
      usuario.Permisos.Add(Permiso.UsuarioAlta);
      usuario.Permisos.Add(Permiso.UsuarioBaja);
      usuario.Permisos.Add(Permiso.UsuarioModificacion);
      usuario.Permisos.Add(Permiso.UsuariosListar);
      usuario.IsAdmin = true;
    }
    else
      usuario.Permisos = [];
    repo.AltaDeUsuario(usuario);
  }
}

