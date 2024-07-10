SGE.Aplicacion
│
├── CasosDeUso
│   ├── Expedientes
│   │   ├── CasoDeUsoExpedienteAlta.cs
│   │   ├── CasoDeUsoExpedienteBaja.cs
│   │   ├── CasoDeUsoExpedienteConsultaPorId.cs
│   │   ├── CasoDeUsoExpedienteConsultaTodos.cs
│   │   └── CasoDeUsoExpedienteModificacion.cs
│   ├── Tramites
│   │   ├── CasoDeUsoTramiteAlta.cs
│   │   ├── CasoDeUsoTramiteBaja.cs
│   │   ├── CasoDeUsoTramiteConsultaPorEtiqueta.cs
│   │   ├── CasoDeUsoTramiteConsultaPorId.cs
│   │   └── CasoDeUsoTramiteModificacion.cs
│   └── Usuarios
│       ├── CasoDeUsoListarUsuarios.cs
│       ├── CasoDeUsoUsuarioAlta.cs
│       ├── CasoDeUsoUsuarioAutenticar.cs
│       ├── CasoDeUsoUsuarioBaja.cs
│       ├── CasoDeUsoUsuarioConsultaPorId.cs
│       └── CasoDeUsoUsuarioModificacion.cs
│
├── Entidades
│   ├── Expediente.cs
│   ├── Tramite.cs
│   └── Usuario.cs
│
├── Enumerativos
│   ├── EstadoExpediente.cs
│   ├── EtiquetaTramite.cs
│   └── Permiso.cs
│
├── Excepciones
│   ├── AutorizacionException.cs
│   ├── RepositorioException.cs
│   └── ValidacionException.cs
│
├── Interfaces
│   ├── IEspecificacionCambioEstado.cs
│   ├── IExpedienteRepositorio.cs
│   ├── IServicioActualizacionEstado.cs
│   ├── IServicioAutorizacion.cs
│   ├── ITramiteRepositorio.cs
│   └── IUsuarioRepositorio.cs
│
├── Servicios
│   ├── EspecificacionCambioEstado.cs
│   ├── ServicioActualizacionEstado.cs
│   ├── ServicioAutenticacion.cs
│   └── ServicioAutorizacion.cs
│
└── Validadores
    ├── ExpedienteValidador.cs
    └── TramiteValidador.cs

18 directories, 59 files
