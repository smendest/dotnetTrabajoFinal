namespace SGE.Aplicacion;

public class Usuario
{
  public int Id { get; set; }
  public string? Nombre { get; set; }
  public string? Apellido { get; set; }
  public string? Email { get; set; }
  public string? Password { get; set; }
  public bool IsAdmin { get; } = false;
  public List<Permiso> Permisos { get; set; } = [];

  // public List<Expediente>? ExpedientesAsociados { get; set; }
  // public List<Tramite>? TramitesAsociados { get; set; }

  public Usuario()
  {
    if (Id == 1)
    {
      IsAdmin = true;
      // Le asignamos todos los permisos al administrador
      Permisos.Add(Permiso.ExpedienteAlta);
      Permisos.Add(Permiso.ExpedienteBaja);
      Permisos.Add(Permiso.ExpedienteModificacion);
      Permisos.Add(Permiso.TramiteAlta);
      Permisos.Add(Permiso.TramiteBaja);
      Permisos.Add(Permiso.TramiteModificacion);
      Permisos.Add(Permiso.UsuarioAlta);
      Permisos.Add(Permiso.UsuarioBaja);
      Permisos.Add(Permiso.UsuarioModificacion);
      Permisos.Add(Permiso.UsuariosListar);
    }
  }

  public override string ToString()
  {
    return $"Id:{Id} - Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}, Password: {Password} ";
  }


}
