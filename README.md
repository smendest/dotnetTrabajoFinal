# Seminario .Net - Trabajo final 
## Sistema para la gestión de expedientes


### Correcciones

- [??] Falta mucha funcionalidad a la interfaz. 
- [x] Hay errores con las páginas en relación al usuario que inicia la sesión. 
  - Incluso utilizando el menu de administración hay páginas con error 404 (http://localhost:5003/buscartramiteporetiqueta1) borrando el último ‘1’ de la url funciona la página. Sin embargo no es buena idea identificar el usuario en la url porque fácilmente podríamos hacernos pasar por otro usuario.
- [x] Tampoco funcionan otras páginas como http://localhost:5003/modificartramite/6 cuando intento modificar un trámite de la lista de trámites
- [ ] No se puede elegir el estado del expediente o la etiqueta del trámite en las altas y modificaciones
- [??] Falta toda la funcionalidad manejo de permisos de los usuarios
    * ¿No se encuentra en el servicio de autorización?