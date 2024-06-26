﻿using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepoSqlite
{
  public static void Inicializar()
  {
    using var context = new RepoContext();
    if (context.Database.EnsureCreated())
    {
      Console.WriteLine("Se creó base de datos");

      // Inicialización db con algunos expedientes y sus trámites asociados:

      context.Expedientes.Add(new Expediente()
      {
        Caratula = "Primer expediente",
        FechaCreacion = DateTime.Parse("5/12/2024 8:57:20 PM"),
        FechaUltimaModif = DateTime.Parse("5/12/2024 8:57:20 PM"),
        Estado = EstadoExpediente.RecienIniciado,
        UserId = 1,
        TramitesAsociados = new List<Tramite>(){
          new Tramite() {
            Contenido = "Primer trámite",
            Etiqueta = EtiquetaTramite.EscritoPresentado,
            FechaCreacion = DateTime.Parse("6/12/2024 9:50:00 PM"),
            FechaUltimaModif = DateTime.Parse("6/12/2024 9:50:00 PM"),
            ExpedienteId = 1,
            UserId = 1,
          }
        }
      });
      context.Expedientes.Add(new Expediente()
      {
        Caratula = "Segundo expediente",
        FechaCreacion = DateTime.Parse("6/12/2024 9:50:00 PM"),
        FechaUltimaModif = DateTime.Parse("6/12/2024 9:50:00 PM"),
        Estado = EstadoExpediente.RecienIniciado,
        UserId = 1,
        TramitesAsociados = new List<Tramite>(){
          new Tramite() {
            Contenido = "Segundo trámite",
            Etiqueta = EtiquetaTramite.Despacho,
            FechaCreacion = DateTime.Parse("6/12/2024 9:50:00 PM"),
            FechaUltimaModif = DateTime.Parse("6/12/2024 9:50:00 PM"),
            ExpedienteId = 2,
            UserId = 1,
          }
        }
      });

      context.SaveChanges();
    }
    var connection = context.Database.GetDbConnection();
    connection.Open();
    using (var command = connection.CreateCommand())
    {
      command.CommandText = "PRAGMA journal_mode=DELETE;";
      command.ExecuteNonQuery();
    }
  }
}
