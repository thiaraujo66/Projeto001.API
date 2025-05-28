using System.ComponentModel.DataAnnotations;

namespace Projeto001.Models.Request.EnderecoRequest
{
    public class ListarEnderecoRequest
    {

        [Required]
        public int IdPessoa { get; set; }
    }
}
