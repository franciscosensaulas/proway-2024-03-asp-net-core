using SupermercadoRepositorios.Repositorios;
using SupermercadoServicos.Dtos.Autenticacao;
using SupermercadoServicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SupermercadoServicos.Servicos
{
    public class AutenticacaoServico : IAutenticacaoServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AutenticacaoServico(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public void Autenticar(AutenticacaoDto dto)
        {
            var usuario = _usuarioRepositorio.ObterPorEmailSenha(dto.Email, dto.Senha);
            if (usuario == null)
                throw new Exception("Usuário n encontrado");

            var usuarioJson = JsonSerializer.Serialize(usuario);
            session.SetString("usuarioSessao", usuarioJson);
        }

        public void Sair()
        {
            throw new NotImplementedException();
        }
    }
}
