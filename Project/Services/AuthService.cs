public class AuthService
{
    private bool mostrarContenido = false;

    public bool EstaAutenticado { get; private set; } = false;
    public string UsuarioActual { get; private set; } = "";

    public bool Login(string Usuario, string clave)
    {
        if (Usuario == "Jahazi" && clave == "1298")
        {
            EstaAutenticado = true;
            UsuarioActual = Usuario;
            return true;
        }
        EstaAutenticado = false;
        return false;
    }

    public void Logout()
    {
        EstaAutenticado = false;
        UsuarioActual = "";
    }
}