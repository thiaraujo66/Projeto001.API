using System.Security.Cryptography;
using System.Text;

namespace Projeto001.Domain
{
    public static class Util
    {
        public static string ComputeSha512Hash(string input)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                // Converte a string de entrada em um array de bytes
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // Calcula o hash SHA-512
                byte[] hashBytes = sha512.ComputeHash(inputBytes);

                // Converte o hash em uma string hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // "x2" mantém dois dígitos por byte
                }

                return sb.ToString();
            }
        }
    }
}
