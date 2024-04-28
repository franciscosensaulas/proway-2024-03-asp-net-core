using System.Security.Cryptography;
using System.Text;

namespace SupermercadoRepositorios.Extensions
{
    public static class Sha512ExtensionMethod
    {
        public static string Hash512(this string senha)
        {
            using (var sha512 = SHA512.Create())
            {
                var senhaBytes = Encoding.UTF8.GetBytes(senha);
                var senhaCriptografada = BitConverter.ToString(
                    sha512.ComputeHash(senhaBytes)).Replace("-", "");
                return senhaCriptografada;
            }
        }
    }
}
