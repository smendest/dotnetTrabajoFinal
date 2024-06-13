namespace SGE.Consola;

public class Menu
{
  public static void Ejecutar(int userId)
  {
    bool exit = false;
    int option = 999;
    while (!exit)
    {

      Console.WriteLine("\nElija la acción que de desea realizar incertando el número de la opción:");

      Console.WriteLine("Acciones sobre Expedientes:");
      Console.WriteLine("1) Dar de alta un expediente");
      Console.WriteLine("2) Dar de baja un expediente");
      Console.WriteLine("3) Modificar un expediente");
      Console.WriteLine("4) Solicitar listado completo de expedientes");
      Console.WriteLine("5) Solicitar un expediente determinado");
      Console.WriteLine();
      Console.WriteLine("Acciones sobre Trámites:");
      Console.WriteLine("6) Dar de alta un trámite");
      Console.WriteLine("7) Dar de baja un trámite");
      Console.WriteLine("8) Modificar un trámite");
      Console.WriteLine("9) Solicitar listado de trámites con una etiqueta determinada");
      Console.WriteLine();
      Console.WriteLine("Para salir del programa ingrese 0");
      try
      {
        option = int.Parse(Console.ReadLine() ?? " ");
      }
      catch
      {
        // Asignamos valos para que caiga en la opción default y siga su flujo
        option = 999;
      }

      switch (option)
      {
        case 0:
          exit = true;
          break;
        case 1:
          AccionesExpediente.Agregar(userId);
          break;
        case 2:
          AccionesExpediente.Eliminar(userId);
          break;
        case 3:
          AccionesExpediente.Modificar(userId);
          break;
        case 4:
          AccionesExpediente.ListarTodos();
          break;
        case 5:
          AccionesExpediente.GetById();
          break;
        case 6:
          AccionesTramite.Agregar(userId);
          break;
        case 7:
          AccionesTramite.Eliminar(userId);
          break;
        case 8:
          AccionesTramite.Modificar(userId);
          break;
        case 9:
          AccionesTramite.ListarPorEtiqueta();
          break;

        default:
          ShowErr();
          break;
      }

      string otraAccion = "";
      while ((otraAccion != "y") && (otraAccion != "n"))
      {
        Console.WriteLine("\n¿Desea realizar otra acción? (y/n)");
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
