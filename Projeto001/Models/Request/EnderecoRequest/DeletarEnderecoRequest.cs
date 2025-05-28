using System.ComponentModel.DataAnnotations;

namespace Projeto001.Models.Request.EnderecoRequest
{
    public class DeletarEnderecoRequest
    {

        [Required]
        public int Id { get; set; }
    }
}
