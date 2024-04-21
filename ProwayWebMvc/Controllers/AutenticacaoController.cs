using Microsoft.AspNetCore.Mvc;
using ProwayWebMvc.Models.Autenticacao;

namespace ProwayWebMvc.Controllers
{
    [Route("login")]
    public class AutenticacaoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new AutenticacaoViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Login([FromForm] AutenticacaoViewModel viewModel)
        {
            return View();
        }

        [HttpGet("sair")]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
