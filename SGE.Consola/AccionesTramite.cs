namespace SGE.Consola;
using SGE.Aplicacion;
using SGE.Repositorios;


public class AccionesTramite
{
  static IExpedienteRepositorio RepoExpedientes { get; } = new RepositorioExpedientes();
  static ITramiteRepositorio RepoTramites { get; } = new RepositorioTramitesTXT();
  static TramiteValidador Validador { get; } = new TramiteValidador();
  static IServicioAutorizacion Autorizacion { get; } = new ServicioAutorizacionProvisorio();
  static IEspecificacionCambioEstado Especificacion { get; } = new EspecificacionCambioEstado();
  static IServicioActualizacionEstado ActualizacionEstado { get; } = new ServicioActualizacionEstado(RepoTramites, RepoExpedientes, Especificacion);

  public static void Agregar(int userId)
  {
    try
    {

      var agregarTramite = new CasoDeUsoTramiteAlta(
        RepoTramites,
        Validador,
        Autorizacion,
        ActualizacionEstado
        );
      Console.WriteLine(">>> ALTA DE TRAMITE <<<");
      Console.WriteLine("Ingrese contenido del Tramite (toda en una sola línea): ");
      string content = Console.ReadLine() ?? "";
      Console.WriteLine("Ingrese el id del expediente asociado: ");
      int expedienteAsociado = int.Parse(Console.ReadLine() ?? "0");
      agregarTramite.Ejecutar(new Tramite() { Contenido = content, ExpedienteId = expedienteAsociado }, userId);
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
      var eliminarTramite = new CasoDeUsoTramiteBaja(
        RepoTramites,
        Validador,
        Autorizacion,
        ActualizacionEstado
        );
      Console.WriteLine(">>> BAJA DE TRAMITE <<<");
      Console.WriteLine("Ingrese el id del trámite que desea eliminar: ");
      int id = int.Parse(Console.ReadLine() ?? "0");

      eliminarTramite.Ejecutar(id, userId);
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
      var modificarTramite = new CasoDeUsoTramiteModificacion(
        RepoTramites,
        Validador,
        Autorizacion,
        ActualizacionEstado
        );
      Console.WriteLine("Ingrese el id del trámite que desea modificar: ");
      int idExp = int.Parse(Console.ReadLine() ?? "0");

      /*DUDA: Es correcto utilizar una función del repositorio sin pasar un por un caso de uso?*/
      Tramite tramite = RepoTramites.GetTramiteById(idExp);

      Console.WriteLine("El tramite que desea modificar es el siguiente:");
      Console.WriteLine(tramite);
      Console.WriteLine();
      Console.WriteLine("Ingrese el nuevo contenido:");
      tramite.Contenido = Console.ReadLine() ?? "";
      tramite.Etiqueta = ElegirEtiqueta();
      modificarTramite.Ejecutar(tramite, userId);
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
  }

  private static EtiquetaTramite ElegirEtiqueta()
  {
    Console.WriteLine("Ingrese el número de opción de la etiqueta deseada para generar el listado: ");
    Console.WriteLine("1) EscritoPresentado");
    Console.WriteLine("2) PaseAEstudio");
    Console.WriteLine("3) Despacho");
    Console.WriteLine("4) Resolucion");
    Console.WriteLine("5) Notificacion");
    Console.WriteLine("6) PaseAlArchivo");

    int option = int.Parse(Console.ReadLine() ?? "0");
    switch (option)
    {
      case 1:
        return EtiquetaTramite.EscritoPresentado;
      case 2:
        return EtiquetaTramite.PaseAEstudio;
      case 3:
        return EtiquetaTramite.Despacho;
      case 4:
        return EtiquetaTramite.Resolucion;
      case 5:
        return EtiquetaTramite.Notificacion;
      case 6:
        return EtiquetaTramite.PaseAlArchivo;

      default:
        throw new Exception("Opción de etiqueta incorrecta");
    }
  }

  public static void ListarPorEtiqueta()
  {
    try
    {
      var consultarPorEtiqueta = new CasoDeUsoTramiteConsultaPorEtiqueta(RepoTramites);
      Console.WriteLine("Ingrese la etiqueta para generar el listado: ");
      List<Tramite> lista = consultarPorEtiqueta.Ejecutar(ElegirEtiqueta());

      if (lista.Count == 0)
      {
        throw new Exception("No se encontraron trámites con la etiqueta ingresada.");
      }
      else
      {
        foreach (Tramite expediente in lista)
        {
          Console.WriteLine(expediente);
        }
      }
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
  }
}