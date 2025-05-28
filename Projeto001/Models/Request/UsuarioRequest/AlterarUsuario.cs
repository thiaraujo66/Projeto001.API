using System.ComponentModel.DataAnnotations;

namespace Projeto001.Models.Request.UsuarioRequest
{
    public class AlterarUsuario
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(80, ErrorMessage = "O campo Usuário deve ter no máximo 80 caracteres.")]
        public string Username { get; set; }

        public int Permissao { get; set; }
        public bool AltSenha { get; set; }
    }
}
