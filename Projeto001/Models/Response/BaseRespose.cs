namespace Projeto001.Models.Response
{
    public class BaseRespose<T>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
