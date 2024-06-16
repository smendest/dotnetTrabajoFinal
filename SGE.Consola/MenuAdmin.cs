namespace SGE.Consola;

public class MenuAdmin
{
  public static void Ejecutar()
  {
    int userId = 1;
    bool exit = false;
    int option;
    while (!exit)
    {

      Console.WriteLine("\nElija la acción que de desea realizar incertando el número de la opción:");

      Console.WriteLine("Acciones sobre Usuarios:");
      Console.WriteLine("1) Dar de alta un usuario");
      Console.WriteLine("2) Dar de baja un usuario");
      Console.WriteLine("3) Modificar un usuario");
      Console.WriteLine("4) Solicitar listado completo de usuarios");
      Console.WriteLine("0) Para salir del menu de administrador");
      try
      {
        option = int.Parse(Console.ReadLine() ?? " ");
      }
      catch
      {
        // Asignamos valor para que caiga en la opción default y siga su flujo
        option = 999;
      }

      switch (option)
      {
        case 0:
          exit = true;
          break;
        case 1:
          AccionesUsuario.CrearNuevo();
          break;
        case 2:
          AccionesUsuario.Eliminar(userId);
          break;
        case 3:
          AccionesUsuario.Modificar(userId);
          break;
        case 4:
          AccionesUsuario.ListarTodos(userId);
          break;

        default:
          ShowErr();
          break;
      }

      string otraAccion = "";
      while ((otraAccion != "y") && (otraAccion != "n") && (!exit))
      {
        Console.WriteLine("\n¿Desea realizar otra acción en el menú administrador? (y/n)");
        otraAccion = Console.ReadLine() ?? "";
      }
      if (otraAccion == "n") exit = true;
    }
  }

  private static void ShowErr()
  {
    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
    Console.WriteLine("\n>>>> Debe ingresar un valor válido. Intentelo nuevamente. <<<\n");
    Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n");

  }
}
