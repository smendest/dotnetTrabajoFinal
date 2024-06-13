using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioTramitesTXT : ITramiteRepositorio
{
  // DUDA: Tuve que poner la ruta relativa al repositorio desde SGE.Console. Cómo puedo mejorarlo?
  readonly string _nombreArch = "../SGE.Repositorios/tramites.txt";
  static int s_ultimoId = 0;

  public RepositorioTramitesTXT()
  {
    AssignUniqueId();
  }

  /*DUDA: Estoy repitiendo el método statico AssignUniqueId en ambos repositorios ¿Cómo solucionar?*/
  private void AssignUniqueId()
  {
    // Determinar el último Id utilizado en el archivo si existe
    if (File.Exists(_nombreArch))
    {
      using var sr = new StreamReader(_nombreArch);
      while (!sr.EndOfStream)
      {
        int id = int.Parse(sr.ReadLine() ?? "");
        // Actualizar el último Id utilizado si es mayor que el actual
        if (id > s_ultimoId)
        {
          s_ultimoId = id;
        }
        // Saltar las líneas de los campos del objeto tramite
        sr.ReadLine();  // ExpedienteId
        sr.ReadLine();  // Contenido
        sr.ReadLine();  // Etiqueta
        sr.ReadLine();  // FechaCreacion
        sr.ReadLine();  // FechaUltimaModif
        sr.ReadLine();  // UserId
      }
    }
  }
  public void AgregarTramite(Tramite tramite)
  {
    tramite.Id = ++s_ultimoId;
    using var sw = new StreamWriter(_nombreArch, true);
    sw.WriteLine(tramite.Id);
    sw.WriteLine(tramite.Contenido);
    sw.WriteLine(tramite.Etiqueta);
    sw.WriteLine(tramite.FechaCreacion);
    sw.WriteLine(tramite.FechaUltimaModif);
    sw.WriteLine(tramite.ExpedienteId);
    sw.WriteLine(tramite.UserId);

  }

  /*
Recorrer el archivo preguntando si el Id del expediente es el buscado.
- Copiar a tempFile todas las líneas que no sean del expediente buscado.
- SI es => no se copian las líneas
- Al finalizar se borra el archivo y se crea nuevamente a partir de tempFile.
*/
  public void EliminarTramite(int id)
  {

    string tempFile = Path.GetTempFileName();

    using var sr = new StreamReader(_nombreArch);
    using var sw = new StreamWriter(tempFile);
    string lineId;
    bool tramiteEcontrado = false;

    while (!sr.EndOfStream)
    {
      lineId = sr.ReadLine() ?? "";
      if (lineId == id.ToString())
      {
        tramiteEcontrado = true;
        // Leo todas las propiedades del Trámite encontrado sin copiarlas
        sr.ReadLine();  // Contenido
        sr.ReadLine();  // Etiqueta
        sr.ReadLine();  // FechaCreacion
        sr.ReadLine();  // FechaUltimaModif
        sr.ReadLine();  // ExpedienteId
        sr.ReadLine();  // UsedID
      }
      else
      {
        /*
        Si el Id no corresponde al expediente a eliminar
        se escriben todas las propiedades del expediente
        en el archivo temporal.
      */
        sw.WriteLine(lineId);
        sw.WriteLine(sr.ReadLine());
        sw.WriteLine(sr.ReadLine());
        sw.WriteLine(sr.ReadLine());
        sw.WriteLine(sr.ReadLine());
        sw.WriteLine(sr.ReadLine());
        sw.WriteLine(sr.ReadLine());
      }
    }

    if (tramiteEcontrado)
    {
      File.Delete(_nombreArch);
      File.Move(tempFile, _nombreArch);
    }
    else throw new RepositorioException($"El Trámite con id {id} no fue encontrado en el archivo");

  }

  /* 
    DUDA => Utilizar el validador aquí?
    DUDA => Están OK los return? tuve que agregar uno en cada catch
    DUDA => Están Bien los try-catch?
    TODO: Agregar modificación de Etiqueta.
   */
  public void ModificarTramite(Tramite tramiteModificado)
  {
    string tempFile = Path.GetTempFileName();
    using var sr = new StreamReader(_nombreArch);
    using var sw = new StreamWriter(tempFile);
    string lineId;
    bool tramiteEcontrado = false;

    Tramite tramite = new Tramite();
    while (!sr.EndOfStream)
    {
      lineId = sr.ReadLine() ?? "";
      if (lineId == tramiteModificado.Id.ToString())
      {
        tramiteEcontrado = true;
        // Reemplazamos uno a uno los campos
        sw.WriteLine(lineId);
        sr.ReadLine();  // Contenido
        sw.WriteLine(tramiteModificado.Contenido);
        sr.ReadLine();  // Etiqueta
        sw.WriteLine(tramiteModificado.Etiqueta);
        sr.ReadLine();  // FechaCreacion
        sw.WriteLine(tramiteModificado.FechaCreacion);
        sr.ReadLine();  // FechaUltimaModif
        sw.WriteLine(tramiteModificado.FechaUltimaModif);
        sr.ReadLine();  // ExpedienteId
        sw.WriteLine(tramiteModificado.ExpedienteId);
        sr.ReadLine();  // UsedID
        sw.WriteLine(tramiteModificado.UserId);
      }
      else
      {
        /*
          Si el Id no corresponde al expediente a modificar
          se escriben todas las propiedades del expediente
          en el archivo temporal sin modificación.
        */
        sw.WriteLine(lineId);
        sw.WriteLine(sr.ReadLine());  // Contenido
        sw.WriteLine(sr.ReadLine());  // Etiqueta
        sw.WriteLine(sr.ReadLine());  // FechaCreacion
        sw.WriteLine(sr.ReadLine());  // FechaUltimaModif
        sw.WriteLine(sr.ReadLine());  // ExpedienteId
        sw.WriteLine(sr.ReadLine());  // UsedID
      }
    }
    if (tramiteEcontrado)
    {
      File.Delete(_nombreArch);
      File.Move(tempFile, _nombreArch);
      // File.Replace(tempFile, _nombreArch, null); Es otra opción a tener en cuenta
    }
    else
    {
      throw new RepositorioException($"El Expediente con id {tramiteModificado.Id} no fue encontrado en el archivo");
    }

  }

  Tramite leerTramiteDelRepo(StreamReader sr, bool withoutId = false)
  {
    Tramite tramite = new Tramite();

    if (!withoutId)
      tramite.Id = int.Parse(sr.ReadLine() ?? "");
    tramite.Contenido = sr.ReadLine() ?? "";
    tramite.Etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), sr.ReadLine() ?? "");
    tramite.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
    tramite.FechaUltimaModif = DateTime.Parse(sr.ReadLine() ?? "");
    tramite.ExpedienteId = int.Parse(sr.ReadLine() ?? "");
    tramite.UserId = int.Parse(sr.ReadLine() ?? "");

    return tramite;
  }

  public List<Tramite> ConsultarPorEtiqueta(EtiquetaTramite etiquetaElegida)
  {
    using var sr = new StreamReader(_nombreArch);
    Tramite tramite = new Tramite();
    List<Tramite> lista = new List<Tramite>();

    while (!sr.EndOfStream)
    {
      tramite = leerTramiteDelRepo(sr);
      if (tramite.Etiqueta == etiquetaElegida)
        lista.Add(tramite);
    }

    return lista;
  }

  /*
    Baja performance, se recorre dos veces el archivo.
  */
  public void EliminarTramitesAsociados(int idExpediente)
  {

    using var sr = new StreamReader(_nombreArch);
    int idExpAux, idTramite;

    while (!sr.EndOfStream)
    {
      idTramite = int.Parse(sr.ReadLine() ?? "");
      sr.ReadLine(); // Contenido
      sr.ReadLine(); // Etiqueta
      sr.ReadLine(); // Fecha Creacion
      sr.ReadLine(); // fechaUltimaModif
      idExpAux = int.Parse(sr.ReadLine() ?? "");
      sr.ReadLine();  // UserId

      if (idExpAux == idExpediente)
      {
        EliminarTramite(idTramite);
      }
    }


  }

  public List<Tramite> ConsultarTramitesAsociadosAlExp(int idExpediente)
  {

    using var sr = new StreamReader(_nombreArch);
    List<Tramite> listaTramites = new List<Tramite>();
    Tramite tramite = new Tramite();

    while (!sr.EndOfStream)
    {
      tramite = leerTramiteDelRepo(sr);

      if (tramite.ExpedienteId == idExpediente)
      {
        listaTramites.Add(tramite);
      }
    }

    return listaTramites;


  }

  public Tramite GetTramiteById(int id)
  {
    using var sr = new StreamReader(_nombreArch);
    Tramite tramite = new Tramite();

    tramite = leerTramiteDelRepo(sr);
    while ((!sr.EndOfStream) && (tramite.Id != id))
    {
      tramite = leerTramiteDelRepo(sr);
    }

    if (tramite.Id != id)
    {
      throw new RepositorioException($"El Tramite con id {id} no fue encontrado en el archivo");
    }

    return tramite;

  }

}
