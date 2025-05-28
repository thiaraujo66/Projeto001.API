using System.ComponentModel.DataAnnotations;

namespace Projeto001.Models.Request.UsuarioRequest
{
    public class DeletarUsuarioModel
    {
        [Required]
        public int Id { get; set; }
    }
}
