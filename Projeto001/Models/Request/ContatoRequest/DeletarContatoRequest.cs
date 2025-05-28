using System.ComponentModel.DataAnnotations;

namespace Projeto001.Models.Request.ContatoRequest
{
    public class DeletarContatoRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
