using System.ComponentModel.DataAnnotations;

namespace Projeto001.Models.Request.ContatoRequest
{
    public class ListarContatoRequest
    {
        [Required]
        public int IdPessoa { get; set; }
    }
}
