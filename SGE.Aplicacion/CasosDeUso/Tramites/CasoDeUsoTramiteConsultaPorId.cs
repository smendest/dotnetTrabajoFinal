namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorId(
  ITramiteRepositorio repoTramite
  )
{
  public Tramite Ejecutar(int idTramite)
  {

    return repoTramite.GetTramiteById(idTramite);

  }

}
