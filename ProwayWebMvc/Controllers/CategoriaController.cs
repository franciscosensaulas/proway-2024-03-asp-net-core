using Microsoft.AspNetCore.Mvc;
using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Repositorios;

namespace ProwayWebMvc.Controllers
{
    [Route("categoria")]
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            var repositorio = new CategoriaRepositorio();
            var categorias = repositorio.ObterTodos();

            ViewBag.Categorias = categorias;
            return View();
        }

        [HttpGet("novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost("novo")]
        public IActionResult Create([FromForm] string nome)
        {
            var categoria = new Categoria();
            categoria.Nome = nome;

            var repositorio = new CategoriaRepositorio();
            repositorio.Cadastrar(categoria);

            return RedirectToAction("Index");
        }

        [HttpGet("apagar")]
        // FromForm => post
        // FromQuery => get => query url?name=Francisco, name é um query param
        public IActionResult Apagar([FromQuery] int id)
        {
            var repositorio = new CategoriaRepositorio();
            repositorio.Apagar(id);

            return RedirectToAction("Index");
        }
            
        [HttpGet("editar")]
        public IActionResult Editar([FromQuery] int id)
        {
            var repositorio = new CategoriaRepositorio();
            var categoria = repositorio.ObterPorId(id);

            ViewBag.Categoria = categoria;
            return View();
        }

        [HttpPost("editar")]
        public IActionResult Update([FromQuery] int id, [FromForm] string nome)
        {
            var repositorio = new CategoriaRepositorio();
            var categoria = repositorio.ObterPorId(id);
            categoria.Nome = nome;

            repositorio.Atualizar(categoria);

            return RedirectToAction("Index");
        }
    }
}
