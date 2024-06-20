using SGE.UI.Components;

//agregamos estas directivas using
using SGE.Repositorios;
using SGE.Aplicacion;
using System.Diagnostics;


var builder = WebApplication.CreateBuilder(args);

//agregamos estos servicios al contenedor DI
// Casos de uso
builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaPorId>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaTodos>();
builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>();
builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
builder.Services.AddTransient<CasoDeUsoTramiteBaja>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorEtiqueta>();
builder.Services.AddTransient<CasoDeUsoTramiteModificacion>();
builder.Services.AddTransient<CasoDeUsoUsuarioAlta>();
builder.Services.AddTransient<CasoDeUsoUsuarioAutenticar>();
builder.Services.AddTransient<CasoDeUsoUsuarioBaja>();
builder.Services.AddTransient<CasoDeUsoUsuarioModificacion>();
builder.Services.AddScoped<IExpedienteRepositorio, RepositorioExpedientes>();
builder.Services.AddScoped<ITramiteRepositorio, RepositorioTramites>();
builder.Services.AddScoped<IUsuarioRepositorio, RepositorioUsuario>();

// Dependendias de los casos de uso
builder.Services.AddTransient<ExpedienteValidador>();
builder.Services.AddTransient<TramiteValidador>();
builder.Services.AddTransient<ServicioAutenticacion>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddScoped<IEspecificacionCambioEstado, EspecificacionCambioEstado>();
builder.Services.AddScoped<IServicioActualizacionEstado, ServicioActualizacionEstado>();


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

/*Inicializamos base de datos*/
RepoSqlite.Inicializar();
using var context = new RepoContext();
{
    Debug.WriteLine("Inicializacion de base de datos\n");
    Debug.WriteLine("-- Tabla Expedientes --");
    foreach (var exp in context.Expedientes)
    {
        Debug.WriteLine($"Id:{exp.Id} {exp.Caratula} -  Creado: {exp.FechaCreacion} - Modificado: {exp.FechaUltimaModif} - Estado: {exp.Estado} - Id de Usuario: {exp.UserId} ");
    }

    Debug.WriteLine("\n-- Tabla Tramites --");
    foreach (var tr in context.Tramites)
    {
        Debug.WriteLine($"Id:{tr.Id} - {tr.Contenido} - {tr.Etiqueta} - Expediente asociado: {tr.ExpedienteId} - Usuario: {tr.UserId}-  Creado: {tr.FechaCreacion} - Modificado: {tr.FechaUltimaModif}");
    }

    Debug.WriteLine("\n-- Tabla Usuarios --");
    foreach (var user in context.Usuarios)
    {
        Debug.WriteLine($"Id:{user.Id} - Nombre: {user.Nombre}, Apellido: {user.Apellido}, Email: {user.Email}, Password: {user.Password} ");
    }
    Debug.WriteLine("Inicializacion de base de datos finalizada \n");
}


app.Run();
