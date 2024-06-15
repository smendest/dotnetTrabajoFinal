using SGE.Consola;
using SGE.Repositorios;

/*Inicializamos base de datos*/
RepoSqlite.Inicializar();
using var context = new RepoContext();
{
  Console.WriteLine("Inicializacion de base de datos\n");
  Console.WriteLine("-- Tabla Expedientes --");
  foreach (var exp in context.Expedientes)
  {
    Console.WriteLine($"Id:{exp.Id} {exp.Caratula} -  Creado: {exp.FechaCreacion} - Modificado: {exp.FechaUltimaModif} - Estado: {exp.Estado} - Id de Usuario: {exp.UserId} ");
  }

  Console.WriteLine("\n-- Tabla Tramites --");
  foreach (var tr in context.Tramites)
  {
    Console.WriteLine($"Id:{tr.Id} - {tr.Contenido} - {tr.Etiqueta} - Expediente asociado: {tr.ExpedienteId} - Usuario: {tr.UserId}-  Creado: {tr.FechaCreacion} - Modificado: {tr.FechaUltimaModif}");
  }

  Console.WriteLine("\n-- Tabla Usuarios --");
  foreach (var user in context.Usuarios)
  {
    Console.WriteLine($"Id:{user.Id} - Nombre: {user.Nombre}, Apellido: {user.Apellido}, Email: {user.Email}, Password: {user.Password} ");
  }
  Console.WriteLine("Inicializacion de base de datos finalizada \n");
}

Console.WriteLine("Ingrese su id de usuario: ");
bool idValido = false;
int userId = 0;
while (!idValido)
{
  string? input = Console.ReadLine();
  if (string.IsNullOrWhiteSpace(input))
  {
    Console.WriteLine("Ingrese un id válido (número entero positivo).");
  }
  else
  {
    userId = int.Parse(input);
    idValido = true;
  }
}

Menu.Ejecutar(userId);

