# Seminario .Net - Trabajo final 
## Sistema para la gestión de expedientes


### Error de Navegación que no pude solucionar en Blazor 

La navegación desde la página de bienvenida al menu princial, luego de iniciar sesión, no funciona y no he encontrado la razón. En mi opinión, por lo que veo del código debería funcionar sin problemas:

`Home.razor`
```c#
try
{
  if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
  {
    autenticarUsuario.Ejecutar(email, password, out userId);
    @* No funciona la navegación a pesar de intentarlo de muchas formas *@
    Navegador.NavigateTo($"/menuprincipal/{userId}");

  }
  else
  {
    throw new Exception("Debe ingresar email y password");
  }
}
catch(Exception e)
{
  MensajeError = e.Message;
  ShowError = true;
}
```
