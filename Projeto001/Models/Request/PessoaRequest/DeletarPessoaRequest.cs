using System.ComponentModel.DataAnnotations;

namespace Projeto001.Models.Request.PessoaRequest
{
    public class DeletarPessoaRequest
    {

        [Required]
        public int Id { get; set; }
    }
}
