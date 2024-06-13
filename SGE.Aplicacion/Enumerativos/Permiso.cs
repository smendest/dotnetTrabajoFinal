namespace SGE.Aplicacion;

public enum Permiso
{
  // Cada usuario podrá poseer varios de los permisos que se detallan a continuación:
  ExpedienteAlta, // Puede realizar altas de expedientes
  ExpedienteBaja, // Puede realizar bajas de expedientes
  ExpedienteModificacion, // Puede realizar modificaciones de expedientes
  TramiteAlta, // Puede realizar altas de trámites
  TramiteBaja, // Puede realizar bajas de trámites
  TramiteModificacion, // Puede realizar modificaciones de trámites
}
