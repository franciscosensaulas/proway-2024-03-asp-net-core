using Microsoft.AspNetCore.Http;

namespace SupermercadoServicos.Interfaces
{
    public interface IArquivoUploadServico
    {
        string ArmazenarArquivo(IFormFile? arquivo, string caminhoArquivos);
    }
}
