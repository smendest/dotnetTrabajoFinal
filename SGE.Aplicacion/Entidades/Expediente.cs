namespace SGE.Aplicacion;

public class Expediente
{
  /*
  Atributos:
  - El Id del ¿trámite?, un identificador numérico único
  - La carátula, texto ingresado por el usuario
  - La fecha y hora de creación
  - La fecha y hora de la última modificación
  - El usuario que realizó la última modificación, identificado por su Id de usuario
  - El estado del expediente.
  */
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
