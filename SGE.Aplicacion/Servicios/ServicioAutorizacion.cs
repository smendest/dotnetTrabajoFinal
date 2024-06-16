namespace SGE.Aplicacion;
/*
Este servicio siempre debe responder true cuando el IdUsuario sea igual a 1 y false en cualquier otro caso (no hace falta realizar
 ninguna verificación). 

Utilizaremos este servicio provisional temporalmente hasta que la gestión completa de usuarios esté implementada en la próxima entrega. 
En ese momento, se reemplazará ServicioAutorizacionProvisorio por un servicio de autorización definitivo que verificará adecuadamente si
el usuario tiene el permiso por el cual se está consultando.
*/
public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
  public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
  {
    return IdUsuario == 1;
  }
}
