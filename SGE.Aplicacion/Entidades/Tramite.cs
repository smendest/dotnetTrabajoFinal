namespace SGE.Aplicacion;

public class Tramite
{
  public int Id { get; set; }
  public string? Contenido { get; set; }
  public EtiquetaTramite Etiqueta { get; set; }
  public DateTime FechaCreacion { get; set; }
  public DateTime FechaUltimaModif { get; set; }
  public int ExpedienteId { get; set; }
  public int UserId { get; set; }
  public override string ToString()
  {
    return $"Id:{Id} - {Contenido} - {Etiqueta} - Expediente asociado: {ExpedienteId} - Usuario: {UserId}-  Creado: {FechaCreacion} - Modificado: {FechaUltimaModif} ";
  }


}
