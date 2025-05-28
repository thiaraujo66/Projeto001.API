using System.ComponentModel.DataAnnotations;

namespace Projeto001.Models.Request.EnderecoRequest
{
    public class CriarEnderecoRequest
    {
        [Required]
        [MaxLength(9, ErrorMessage = "O campo Cep deve ter no máximo 9 caracteres.")]
        public string Cep { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O campo Logradouro deve ter no máximo 100 caracteres.")]
        public string Logradouro { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O campo Bairro deve ter no máximo 100 caracteres.")]
        public string Bairro { get; set; }

        [MaxLength(30, ErrorMessage = "O campo Número deve ter no máximo 30 caracteres.")]
        public string Numero { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O campo Cidade deve ter no máximo 100 caracteres.")]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = "O campo UF deve ter no máximo 2 caracteres.")]
        public string Uf { get; set; }

        [MaxLength(100, ErrorMessage = "O campo Complemento deve ter no máximo 100 caracteres.")]
        public string Complemento { get; set; }

        [Required]
        public int IdPessoa { get; set; }
    }
}
