using SGE.UI.Components;

//agregamos estas directivas using
using SGE.Repositorios;
using SGE.Aplicacion;


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

app.Run();
