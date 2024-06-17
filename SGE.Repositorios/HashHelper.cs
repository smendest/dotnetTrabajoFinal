namespace SGE.Repositorios;

using System.Security.Cryptography;
using System.Text;

public static class HashHelper
{
  public static string HashPassword(string rawData)
  {
    // Crear una instancia de SHA256
    using (SHA256 sha256Hash = SHA256.Create())
    {
      // Convertir la cadena de texto a un arreglo de bytes
      byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

      // Convertir el arreglo de bytes a una cadena de texto hexadecimal
      StringBuilder builder = new StringBuilder();
      foreach (byte b in bytes)
      {
        builder.Append(b.ToString("x2"));
      }

      return builder.ToString();
    }
  }
}
