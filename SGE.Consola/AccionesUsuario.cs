namespace SGE.Consola;
using SGE.Aplicacion;
using SGE.Repositorios;


public class AccionesUsuario
{
  static IExpedienteRepositorio RepoExpedientes { get; } = new RepositorioExpedientesTXT();
  static ITramiteRepositorio RepoTramites { get; } = new RepositorioTramitesTXT();
  static ExpedienteValidador Validador { get; } = new ExpedienteValidador();
  static IServicioAutorizacion Autorizacion { get; } = new ServicioAutorizacionProvisorio();

  public static void Agregar(int userId)
  {
    try
    {

      var agregarExpediente = new CasoDeUsoExpedienteAlta(RepoExpedientes, Validador, Autorizacion);
      Console.WriteLine(">>>> ALTA DE EXPEDIENTE <<<<");
      Console.WriteLine("Ingrese la carátula del expediente (toda en una sola línea): ");
      string caratula = Console.ReadLine() ?? "";
      agregarExpediente.Ejecutar(new Expediente() { Caratula = caratula }, userId);
      SuccesLog();
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
  }

  public static void Eliminar(int userId)
  {
    try
    {

      var eliminarExpediente = new CasoDeUsoExpedienteBaja(RepoExpedientes, RepoTramites, Validador, Autorizacion);
      Console.WriteLine(">>> BAJA DE EXPEDIENTE ");
      Console.WriteLine("Ingrese el id de expediente que desea eliminar: ");
      int id = int.Parse(Console.ReadLine() ?? "0");

      eliminarExpediente.Ejecutar(id, userId);
      SuccesLog();
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }

  }

  public static void Modificar(int userId)
  {
    try
    {
      var modificarExpediente = new CasoDeUsoExpedienteModificacion(RepoExpedientes, Validador, Autorizacion);
      var consultarPorId = new CasoDeUsoExpedienteConsultaPorId(RepoExpedientes, RepoTramites);
      Console.WriteLine("Ingrese el id del expediente que desea modificar: ");
      int idExp = int.Parse(Console.ReadLine() ?? "0");
      Expediente expediente = consultarPorId.Ejecutar(idExp);
      Console.WriteLine("El expediente que desea modificar es el siguiente:");
      Console.WriteLine(expediente);
      Console.WriteLine();
      Console.WriteLine("Ingrese la nueva carátula (El único campo modificable):");
      expediente.Caratula = Console.ReadLine() ?? "";
      modificarExpediente.Ejecutar(expediente, userId);
      SuccesLog();
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
  }

  public static void ListarTodos()
  {
    try
    {
      var consultarTodos = new CasoDeUsoExpedienteConsultaTodos(RepoExpedientes);
      List<Expediente> listadoCompleto = consultarTodos.Ejecutar();

      foreach (Expediente expediente in listadoCompleto)
      {
        Console.WriteLine(expediente);
      }
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
  }

  public static void GetById()
  {
    try
    {
      var consultarPorId = new CasoDeUsoExpedienteConsultaPorId(RepoExpedientes, RepoTramites);
      Console.WriteLine("Ingresar el id del expediente requerido: ");
      int id = int.Parse(Console.ReadLine() ?? "0");
      Expediente expediente = consultarPorId.Ejecutar(id);
      Console.WriteLine("Expediente: ");
      Console.WriteLine(expediente);
      Console.WriteLine("Trámites asociados al expediente: ");
      if (expediente.TramitesAsociados != null)
      {
        foreach (Tramite tramite in expediente.TramitesAsociados)
        {
          Console.WriteLine(tramite);
        }
      }
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
  }

  private static void SuccesLog()
  {
    Console.WriteLine("\n==== Tarea realizada con éxito ====\n");
  }

}
