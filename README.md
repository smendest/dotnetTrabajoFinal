# Seminario .Net - Trabajo final 
## Sistema para la gestión de expedientes

Al finalizar una tarea se debe colocar una `x` entre los corchetes de cada item (checkbox): De `- [ ]` a `- [x]`. Para tener un control qué tareas quedan por completar.

Las secciones que agrupan tareas pueden modificarse, fusionarse u omitirse si se considera necesario durante el proceso de desarrollo. Han sido copiadas directamente desde el enunciado del trabajo.

### Gestión de Usuarios:
- [x] Desarrollar la funcionalidad necesaria para la gestión de usuarios. Cada usuario debe tener nombre, apellido, correo electrónico, contraseña y una lista de permisos.
- [x] Los usuarios pueden tener múltiples permisos. Sólo el Administrador tendrá los permisos necesarios para listar, dar de baja y modificar cualquier usuario o sus permisos.
- [x] El primer usuario que se registre en el sistema será el Administrador, quien contará con todos los permisos del sistema, incluyendo la capacidad exclusiva para realizar las tareas mencionadas sobre otros usuarios.
- [x] Definir los repositorios y casos de uso que se consideren necesarios.

#### ToDo list para Gestión de Usuarios
  - [x] Crear repositorio de usuarios.
    <!-- - [ ] Crear clase abstracta RepositorioBase. -->
  - [x] Caso de uso alta de un usuario.
    - Desde dónde se hará el alta? => Interfaz
    - Allí se le asignarán los permisos? cuáles? => Ver más abajo
  - [x] Caso de uso listar usuarios (solo admin).
  - [x] Caso de uso baja de usuario (solo admin).
  - [x] Caso de uso modificar usuario (solo admin).

### Persistencia de Datos:
- [x] En el proyecto SGE.Repositorios, emplear Entity Framework Core para persistir datos en una base de datos SQLite, siguiendo la metodología “code first”.
- [x] Implementar y probar todas las interacciones con la base de datos.
  - [x] Repo Expedientes
    - [x] Alta expediente
    - [x] Baja expediente
    - [x] Modif expediente
    - [x] Get by id
    - [x] Consultar todos
  - [x] Repo Tramites
    - [x] Reemplazar ConsultarTramitesAsociadosAlExp
    - [x] Agregar
    - [x] Eliminar
    - [x] Modificar
    - [x] Listar por etiqueta
- [x] Al final probar cambio automático de Estado (Se necesita haber terminado la db)

### Permisos de Usuario:
- [x] Los usuarios nuevos contarán inicialmente solo con permisos de lectura.
- [x] Solo el Administrador podrá asignar permisos adicionales.

### Esquema de Permisos:
Mantener el mismo esquema de permisos definido en la primera entrega, con algunas
modificaciones:

- [x] En esta entrega, se considerará la posibilidad de que un usuario tenga permiso para eliminar expedientes pero no para eliminar trámites individuales. Al eliminar un expediente, todos los trámites asociados se eliminarán automáticamente, incluso si el usuario no tiene el permiso para dar de baja trámites (permiso TramiteBaja).
- [x] De manera similar, un usuario puede tener permiso para modificar trámites pero no para modificar expedientes. Los cambios automáticos en el estado del expediente al modificar, eliminar o agregar un trámite se realizarán de la misma manera, incluso si el usuario no tiene permisos para modificar expedientes (permiso ExpedienteModificacion).

### Servicio de Autorización:
- [x] Desarrollar el servicio de autorización ServicioAutorizacion que implemente la interfaz IServicioAutorizacion, reemplazando al servicio de autorización provisorio de la entrega inicial
- [x] Este servicio debe verificar realmente si el usuario tiene el permiso requerido.

### Almacenamiento del hash
- [x] El hash de la contraseña debe almacenarse en la base de datos, nunca la contraseña en sí. Para verificar la identidad del usuario al iniciar sesión, se vuelve a calcular el hash de la contraseña ingresada y se compara con el hash almacenado.
- [x] Si los hashes coinciden, el usuario ha ingresado la contraseña correcta y se le permite acceder al sistema.

+ [x] CasoDeUso modificar usuario propio (flujo de gestión)
+ [x] SignIn con email en lugar de id
+ [x] Establecer la propiedad journal mode de la base de datos sqlite en DELETE ???

### Interfaz de Usuario:
- [ ] Descartar el proyecto SGE.Consola de la primera entrega.
- [ ] Desarrollar una nueva interfaz de usuario en un proyecto llamado SGE.UI utilizando Blazor. Diseñar libremente esta interfaz de manera que toda la funcionalidad desarrollada en la primera entrega sea accesible desde esta interfaz, agregando la gestión de usuarios requerida.

### Acceso Administrativo:
- [ ] El menú de gestión de usuarios será visible exclusivamente para el Administrador tras iniciar sesión con sus credenciales.

### Flujo de Gestión:
- [ ] Al iniciar la aplicación, se presentará una pantalla de bienvenida que permitirá a los usuarios iniciar sesión o registrarse.
- [ ] En caso de registro, se proporcionará un formulario para ingresar los datos personales y establecer una contraseña.
- [ ] Los usuarios tendrán la libertad de modificar sus datos personales y contraseña en cualquier momento.
- [ ] Por simplicidad no se implementará ningún mecanismo de recuperación de contraseña. En caso de olvido de contraseña, el usuario deberá contactar al Administrador para restablecerla.
- [x] Las contraseñas no se almacenarán directamente en la base de datos; en su lugar, se utilizará una función de hash para mayor seguridad.



