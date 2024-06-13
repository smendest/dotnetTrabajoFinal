﻿using SGE.Consola;


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

