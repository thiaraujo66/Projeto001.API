using System.ComponentModel.DataAnnotations;

namespace Projeto001.Models.Request.ContatoRequest
{
    public class AtualizarContatoRequest
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(80, ErrorMessage = "O campo Conteúdo deve ter no máximo 80 caracteres.")]
        public string Conteudo { get; set; }

        public int? Tipo { get; set; }
        
    }
}
