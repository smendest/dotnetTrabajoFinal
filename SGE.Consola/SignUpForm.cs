namespace SGE.Consola;

public class SignUpForm
{
  public static void Ejecutar()
  {
    AccionesUsuario.CrearNuevo();
    SignInForm.Ejecutar();
  }

}
