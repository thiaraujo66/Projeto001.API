using System.ComponentModel.DataAnnotations;

namespace Projeto001.Models.Request.UsuarioRequest
{
    public class AlterarSenhaModel
    {
        [Required]
        [MaxLength(80, ErrorMessage = "O campo Usuário deve ter no máximo 80 caracteres.")]
        public string Username { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string NovaSenha { get; set; }
    }
}
