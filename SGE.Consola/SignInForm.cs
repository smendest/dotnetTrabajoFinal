namespace SGE.Consola;

public class SignInForm
{
  public static void Ejecutar()
  {
    bool exit = false;
    while (!exit)
    {
      if (AccionesUsuario.Autenticar(out int idUsuario))
      {
        MenuPrincipal.Ejecutar(idUsuario);
        exit = true;
      }
      else
        Console.WriteLine("Ingrese los datos nuevamente");
    }
  }
}
