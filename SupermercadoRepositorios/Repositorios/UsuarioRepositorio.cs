using SupermercadoRepositorios.BancoDados;
using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Repositorios.Base;

namespace SupermercadoRepositorios.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(SupermercadoContexto contexto) : base(contexto)
        {
        }

        public Usuario? ObterPorEmailSenha(string email, string senha)
        {
            return _dbSet.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();
        }
    }
}
