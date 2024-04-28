using Microsoft.AspNetCore.Http;
using SupermercadoServicos.Dtos.Autenticacao;

namespace SupermercadoServicos.Interfaces
{
    public interface IAutenticacaoServico
    {
        void Autenticar(AutenticacaoDto dto, ISession sessao);
        void Sair(ISession session);

    }
}
