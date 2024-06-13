using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioExpedientesTXT : IExpedienteRepositorio
{
  // DUDA: Tuve que poner la ruta relativa al repositorio desde SGE.Console. Cómo puedo mejorarlo?
  readonly string _nombreArch = "../SGE.Repositorios/expedientes.txt";
  static int s_ultimoId = 0;

  public RepositorioExpedientesTXT()
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
        // Saltar las líneas de los campos Caratula, FechaCreacion, FechaUltimaModif, UsedId y Estado
        sr.ReadLine();
        sr.ReadLine();
        sr.ReadLine();
        sr.ReadLine();
        sr.ReadLine();
      }
    }

  }

  public void AgregarExpediente(Expediente expediente)
  {
    expediente.Id = ++s_ultimoId;
    using var sw = new StreamWriter(_nombreArch, true);
    sw.WriteLine(expediente.Id);
    sw.WriteLine(expediente.Caratula);
    sw.WriteLine(expediente.FechaCreacion);
    sw.WriteLine(expediente.FechaUltimaModif);
    sw.WriteLine(expediente.UserId);
    sw.WriteLine(expediente.Estado);
  }

  public List<Expediente> ListarExpedientes()
  {
    var resultado = new List<Expediente>();
    using var sr = new StreamReader(_nombreArch);
    while (!sr.EndOfStream)
    {
      var expediente = leerExpedienteDelRepo(sr);
      resultado.Add(expediente);
    }

    return resultado;
  }

  /*
  Recorrer el archivo preguntando si el Id del expediente es el buscado.
  - Copiar a tempFile todas las líneas que no sean del expediente buscado.
  - SI es => no se copian las líneas
  - Al finalizar se borra el archivo y se crea nuevamente a partir de tempFile.
  */
  public void EliminarExpediente(int id)
  {
    string tempFile = Path.GetTempFileName();

    using var sr = new StreamReader(_nombreArch);
    using var sw = new StreamWriter(tempFile);
    string lineId;
    bool expedienteEcontrado = false;

    while (!sr.EndOfStream)
    {
      lineId = sr.ReadLine() ?? "";
      if (lineId == id.ToString())
      {
        expedienteEcontrado = true;
        // Leo todas las propiedades del expediente encontrado sin copiarlas
        sr.ReadLine();  // Caratula
        sr.ReadLine();  // FechaCreacion
        sr.ReadLine();  // FechaUltimaModif
        sr.ReadLine();  // UsedID
        sr.ReadLine();  // Estado
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

      }
    }

    if (expedienteEcontrado)
    {
      File.Delete(_nombreArch);
      File.Move(tempFile, _nombreArch);
      // File.Replace(tempFile, _nombreArch, null); Es otra opción a tener en cuenta
    }
    else throw new RepositorioException($"El Expediente con id {id} no fue encontrado en el archivo");

  }

  // TODO: Rehacer similar al Eliminar()
  public void ModificarExpediente(Expediente expModificado)
  {
    string tempFile = Path.GetTempFileName();
    using var sr = new StreamReader(_nombreArch);
    using var sw = new StreamWriter(tempFile);
    string lineId;
    bool expedienteEcontrado = false;

    while (!sr.EndOfStream)
    {
      lineId = sr.ReadLine() ?? "";
      if (lineId == expModificado.Id.ToString())
      {
        expedienteEcontrado = true;
        // Reemplazamos uno a uno los campos
        sw.WriteLine(lineId);
        sr.ReadLine();  // Caratula
        sw.WriteLine(expModificado.Caratula);
        sr.ReadLine();  // FechaCreacion
        sw.WriteLine(expModificado.FechaCreacion);
        sr.ReadLine();  // FechaUltimaModif
        sw.WriteLine(expModificado.FechaUltimaModif);
        sr.ReadLine();  // UsedID
        sw.WriteLine(expModificado.UserId);
        sr.ReadLine();  // Estado
        sw.WriteLine(expModificado.Estado);
      }
      else
      {
        /*
          Si el Id no corresponde al expediente a modificar
          se escriben todas las propiedades del expediente
          en el archivo temporal sin modificación.
        */
        sw.WriteLine(lineId);
        sw.WriteLine(sr.ReadLine());
        sw.WriteLine(sr.ReadLine());
        sw.WriteLine(sr.ReadLine());
        sw.WriteLine(sr.ReadLine());
        sw.WriteLine(sr.ReadLine());

      }
    }
    if (expedienteEcontrado)
    {
      File.Delete(_nombreArch);
      File.Move(tempFile, _nombreArch);
      // File.Replace(tempFile, _nombreArch, null); Es otra opción a tener en cuenta
    }
    else
    {
      throw new RepositorioException($"El Expediente con id {expModificado.Id} no fue encontrado en el archivo");
    }

  }

  Expediente leerExpedienteDelRepo(StreamReader sr, bool withoutId = false)
  {
    Expediente expediente = new Expediente();

    if (!withoutId)
      expediente.Id = int.Parse(sr.ReadLine() ?? "");
    expediente.Caratula = sr.ReadLine() ?? "";
    expediente.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
    expediente.FechaUltimaModif = DateTime.Parse(sr.ReadLine() ?? "");
    expediente.UserId = int.Parse(sr.ReadLine() ?? "");
    expediente.Estado = (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), sr.ReadLine() ?? "");

    return expediente;
  }

  public Expediente GetExpedienteById(int id)
  {
    using var sr = new StreamReader(_nombreArch);
    Expediente expediente = new Expediente();

    expediente = leerExpedienteDelRepo(sr);
    while ((!sr.EndOfStream) && (expediente.Id != id))
    {
      expediente = leerExpedienteDelRepo(sr);
    }

    if (expediente.Id != id)
    {
      throw new RepositorioException($"El Expediente con id {id} no fue encontrado en el archivo");
    }

    return expediente;

  }

  public List<Expediente> ConsultarTodos()
  {
    var sr = new StreamReader(_nombreArch);
    List<Expediente> list = new List<Expediente>();

    while (!sr.EndOfStream)
    {
      list.Add(leerExpedienteDelRepo(sr));

    }

    return list;
  }

}