using System.ComponentModel.DataAnnotations;

namespace Projeto001.Models.Request.UsuarioRequest
{
    public class CriarUsuarioModel
    {
        [Required]
        [MaxLength(80, ErrorMessage = "O campo Usuário deve ter no máximo 80 caracteres.")]
        public string Username { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public int? Permissao { get; set; }

        [Required]
        public int IdPessoa { get; set; }
    }
}
