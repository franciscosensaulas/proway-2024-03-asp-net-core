using SupermercadoServicos.Dtos.Estantes;

namespace SupermercadoServicos.Interfaces
{
    public interface IEstanteServico
    {
        List<EstanteDto> ObterTodos();
        EstanteDto ObterPorId(int id);
        int Cadastrar(EstanteCadastrarDto estanteCadastrarDto);
        void Editar(EstanteEditarDto estanteEditarDto);
        void Apagar(int id);
    }
}
