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

// Console.WriteLine("Ingrese su id de usuario: ");
// bool idValido = false;
// int userId = 0;
// while (!idValido)
// {
//   string? input = Console.ReadLine();
//   if (string.IsNullOrWhiteSpace(input))
//   {
//     Console.WriteLine("Ingrese un id válido (número entero positivo).");
//   }
//   else
//   {
//     userId = int.Parse(input);
//     idValido = true;
//   }
// }