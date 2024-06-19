namespace SGE.Aplicacion;

public class ServicioAutenticacion
{
  public bool IsAuthenticated { get; private set; }

  public event Action? OnChange;

  public void SignIn()
  {
    IsAuthenticated = true;
    NotifyStateChanged();
  }

  public void SignOut()
  {
    IsAuthenticated = false;
    NotifyStateChanged();
  }

  private void NotifyStateChanged() => OnChange?.Invoke();
}