using System.ComponentModel.DataAnnotations;

namespace Projeto001.Models.Response.EnderecoResponse
{
    public class ListarEnderecoResponse
    {
        public int Id { get; set; }

        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public string Numero { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        public string Complemento { get; set; }

        public int? IdPessoa { get; set; }
    }
}
