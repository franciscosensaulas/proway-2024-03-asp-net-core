using Microsoft.AspNetCore.Mvc;
using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Repositorios;

namespace ProwayWebMvc.Controllers
{
    [Route("estante")]
    public class EstanteController : Controller
    {
        public IActionResult Index()
        {
            var repositorio = new EstanteRepositorio();
            var estantes = repositorio.ObterTodos("");
            ViewBag.Estantes = estantes;

            return View();
        }

        [HttpGet("novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost("novo")]
        public IActionResult Create(
            [FromForm] string nome,
            [FromForm] string sigla)
        {
            var repositorio = new EstanteRepositorio();
            var estante = new Estante();
            estante.Nome = nome;
            estante.Sigla = sigla;

            repositorio.Cadastrar(estante);

            return RedirectToAction("Index");
        }

        [HttpGet("apagar")]
        public IActionResult Apagar([FromQuery] int id)
        {
            var repositorio = new EstanteRepositorio();
            repositorio.Apagar(id);

            return RedirectToAction("Index");
        }

        [HttpGet("editar")]
        public IActionResult Editar([FromQuery] int id)
        {
            var repositorio = new EstanteRepositorio();
            var estante = repositorio.ObterPorId(id);
            ViewBag.Estante = estante;

            return View();
        }

        [HttpPost("editar")]
        public IActionResult Update(
            [FromQuery] int id,
            [FromForm] string nome,
            [FromForm] string sigla)
        {
            var repositorio = new EstanteRepositorio();
            var estante = repositorio.ObterPorId(id);
            estante.Nome = nome;
            estante.Sigla = sigla;

            repositorio.Atualizar(estante);

            return RedirectToAction("Index");
        }
    }
}
