using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Repositorios;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public IActionResult ObterTodos()
        {
            var repositorio = new CategoriaRepositorio();
            var categorias = repositorio.ObterTodos();

            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorID(int id)
        {
            var repositorio = new CategoriaRepositorio();
            var categoria = repositorio.ObterPorId(id);
            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Data dados)
        {

            if (dados.Nome.IsNullOrEmpty())
            {
                throw new Exception("Nome não deve ser vazio");
            }

            var categoria = new Categoria();
            categoria.Nome = dados.Nome;

            var repositorio = new CategoriaRepositorio();
            repositorio.Cadastrar(categoria);

            return Created();
        }

        [HttpDelete("/{id}")]
        public IActionResult Apagar([FromQuery] int id)
        {
            var repositorio = new CategoriaRepositorio();
            repositorio.Apagar(id);

            return Ok();
        }

        [HttpPut("/{id}")]
        public IActionResult Update([FromQuery] int id, [FromBody] string nome)
        {
            var repositorio = new CategoriaRepositorio();
            var categoria = repositorio.ObterPorId(id);
            categoria.Nome = nome;

            repositorio.Atualizar(categoria);

            return Ok();
        }
    }

    public class Data
    {
        public string Nome { get; set; }
    }
}
