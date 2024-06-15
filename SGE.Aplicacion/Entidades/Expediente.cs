namespace SGE.Aplicacion;

public class Expediente
{
  public int Id { get; set; }
  public string? Caratula { get; set; }
  public DateTime FechaCreacion { get; set; }
  public DateTime FechaUltimaModif { get; set; }
  public int UserId { get; set; }
  public EstadoExpediente Estado { get; set; }
  public List<Tramite>? TramitesAsociados { get; set; }
  public override string ToString()
  {
    return $"Id:{Id} {Caratula} -  Creado: {FechaCreacion} - Modificado: {FechaUltimaModif} - Estado: {Estado} - Id de Usuario: {UserId} ";
  }

}
