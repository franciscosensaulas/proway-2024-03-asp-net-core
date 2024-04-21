using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Repositorios.Base;

namespace SupermercadoRepositorios.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        Usuario? ObterPorEmailSenha(string email, string senha);
    }
}