﻿namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioBaja(IUsuarioRepositorio repo, IServicioAutorizacion autorizacion)
{
  public void Ejecutar(int idUsuarioAEliminar, int IdUsuarioActual)
  {
    // Verificacación de permisos del usuario.
    if (autorizacion.PoseeElPermiso(IdUsuarioActual, Permiso.UsuarioBaja))
      repo.BajaDeUsuario(idUsuarioAEliminar);
    else
      throw new AutorizacionException();
  }
}
