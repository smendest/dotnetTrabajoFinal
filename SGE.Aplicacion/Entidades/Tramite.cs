namespace SGE.Aplicacion;

public class Tramite
{
  /*
    - El Id del trámite, identificador numérico único entre todos los trámites gestionados por el sistema
    - El Id del expediente al que pertenece, propiedad ExpedienteId mencionada previamente
    - La etiqueta que identifica el tipo de trámite
    - El contenido específico del trámite, texto ingresado por el usuario
    - La fecha y hora de creación del trámite
    - La fecha y hora de la última modificación del trámite
    - El usuario que realizó la última modificación, identificado por su Id de usuario.
  */

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
