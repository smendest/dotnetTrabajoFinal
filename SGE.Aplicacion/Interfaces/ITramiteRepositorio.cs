namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
  void AgregarTramite(Tramite tramite);
  void EliminarTramite(int id);
  void ModificarTramite(Tramite tramiteModificado);
  List<Tramite> ConsultarPorEtiqueta(EtiquetaTramite etiquetaElegida);
  Tramite GetTramiteById(int id);

}
