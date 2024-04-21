using SupermercadoServicos.Dtos.Autenticacao;

namespace SupermercadoServicos.Interfaces
{
    public interface IAutenticacaoServico
    {
        void Autenticar(AutenticacaoDto dto);
        void Sair();

    }
}
