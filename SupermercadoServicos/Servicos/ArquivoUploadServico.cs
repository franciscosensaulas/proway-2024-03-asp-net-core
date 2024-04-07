using Microsoft.AspNetCore.Http;
using SupermercadoServicos.Interfaces;

namespace SupermercadoServicos.Servicos
{
    public class ArquivoUploadServico : IArquivoUploadServico
    {
        public string ArmazenarArquivo(IFormFile? arquivo, string caminhoArquivos)
        {
            if (arquivo is null)
                return string.Empty;

            var caminhoPastaImagens = Path.Combine(caminhoArquivos, "Produtos");

            // Verificar se a pasta não existe
            if (!Directory.Exists(caminhoPastaImagens))
                // Criar a pasta para poder armazenar lá dentro a imagem que o usuário fez o upload
                Directory.CreateDirectory(caminhoPastaImagens);

            var informacaoArquivo = new FileInfo(arquivo.FileName);
            // C:\...\wwwroot\Produtos\219038-239i123-1239481-209838.png
            var nomeArquivo = Guid.NewGuid() + informacaoArquivo.Extension;

            var caminhoArquivo = Path.Combine(caminhoPastaImagens, nomeArquivo);
            using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
            {
                arquivo.CopyTo(stream);
                return nomeArquivo;
            }
        }
    }
}
