namespace SGE.Aplicacion;

public class Usuario
{
  public int Id { get; set; }
  public string? Nombre { get; set; }
  public string? Apellido { get; set; }
  public string? Email { get; set; }
  public string Password { get; set; } = "123456";
  public bool IsAdmin { get; set; } = false;
  public List<Permiso> Permisos { get; set; } = [];

  // public List<Expediente>? ExpedientesAsociados { get; set; }
  // public List<Tramite>? TramitesAsociados { get; set; }

  public override string ToString()
  {
    string permisos = Permisos.Any() ? string.Join(", ", Permisos) : "No tiene permisos";
    return $"Id:{Id} - Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}, Password: {Password}, IsAdmin: {(IsAdmin ? "SI" : "NO")}, Permisos: [{permisos}] ";
  }


}
