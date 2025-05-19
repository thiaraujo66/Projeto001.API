namespace Projeto001.Models.Response.UsuarioResponse
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public int Permissao { get; set; }
    }
}
