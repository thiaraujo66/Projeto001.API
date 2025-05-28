namespace Projeto001.Models.Response.UsuarioResponse
{
    public class ConsultaUsuarioResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Permissao { get; set; }
        public bool AltSenha { get; set; }
        public int IdPessoa { get; set; }
    }
}
