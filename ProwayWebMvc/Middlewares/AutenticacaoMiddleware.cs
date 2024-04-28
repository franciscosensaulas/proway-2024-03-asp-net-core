using SupermercadoRepositorios.Entidades;
using System.Text.Json;

namespace ProwayWebMvc.Middlewares
{
    public class AutenticacaoMiddleware
    {
        private readonly RequestDelegate _next;

        public AutenticacaoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var usuarioSessao = httpContext.Session.GetString("usuarioSessao");
            var controller = httpContext.GetRouteData().Values["controller"]?.ToString() ?? string.Empty;

            if(usuarioSessao == null && controller != "Autenticacao")
            {
                httpContext.Response.Redirect("/login");
                return;
            }

            if(usuarioSessao != null)
            {
                var usuario = JsonSerializer.Deserialize<Usuario>(usuarioSessao);
                httpContext.Items.Add("userName", usuario.Nome);
            }

            await _next(httpContext);
        }
    }
}
