namespace SGE.Aplicacion;

public class Usuario
{
  public int Id { get; set; }
  public string? Nombre { get; set; }
  public string? Apellido { get; set; }
  public string? Email { get; set; }
  public string? Password { get; set; }
  public bool? IsAdmin { get; set; }
  public List<Permiso>? Permisos { get; set; }

  // public Usuario(string nombre, string apellido, string email, string password)
  // {
  //   Nombre = nombre;
  //   Apellido = apellido;
  //   Email = email;
  //   Password = password;
  // }


  public override string ToString()
  {
    return $"Id:{Id} - Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}, Password: {Password} ";
  }


}
