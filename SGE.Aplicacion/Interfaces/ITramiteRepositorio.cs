namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
  void AgregarTramite(Tramite tramite);
  void EliminarTramite(int id);
  void ModificarTramite(Tramite tramiteModificado);
  List<Tramite> ConsultarPorEtiqueta(EtiquetaTramite etiquetaElegida);
  void EliminarTramitesAsociados(int idExpediente);
  List<Tramite> ConsultarTramitesAsociadosAlExp(int idExpediente);
  Tramite GetTramiteById(int id);

}
