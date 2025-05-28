using System.ComponentModel.DataAnnotations;

namespace Projeto001.Models.Request.PessoaRequest
{
    public class CriarPessoaRequest
    {
        [Required]
        [MaxLength(255, ErrorMessage = "O campo Nome deve ter no máximo 255 caracteres.")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(18, ErrorMessage = "O campo CGC deve ter no máximo 18 caracteres.")]
        public string Cgc { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "O campo Email deve ter no máximo 255 caracteres.")]
        public string Email { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [MaxLength(11, ErrorMessage = "O campo CGC deve ter no máximo 18 caracteres.")]
        public string? Rg { get; set; }

        [Required]
        public string Genero { get; set; }

        [MaxLength(255, ErrorMessage = "O campo Nome da Mãe deve ter no máximo 255 caracteres.")]
        public string Mae { get; set; }

        [MaxLength(255, ErrorMessage = "O campo Nome do Pai deve ter no máximo 255 caracteres.")]
        public string Pai { get; set; }
    }
}
