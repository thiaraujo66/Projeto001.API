using Projeto001.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Projeto001.Models.Request.ContatoRequest
{
    public class CriarContatoRequest
    {
        [Required]
        [MaxLength(80, ErrorMessage = "O campo Conteúdo deve ter no máximo 80 caracteres.")]
        public string Conteudo { get; set; }

        [Required]
        public TipoContato Tipo { get; set; }

        [Required]
        public int IdPessoa { get; set; }
    }
}
