using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProwayWebMvc.Models.Autenticacao;
using SupermercadoServicos.Dtos.Autenticacao;
using SupermercadoServicos.Interfaces;

namespace ProwayWebMvc.Controllers
{
    [Route("login")]
    public class AutenticacaoController : Controller
    {
        private readonly IAutenticacaoServico _servico;
        private readonly IMapper _mapper;

        public AutenticacaoController(IAutenticacaoServico servico, IMapper mapper)
        {
            _servico = servico;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new AutenticacaoViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Login([FromForm] AutenticacaoViewModel viewModel)
        {
            var autenticacaoDto = _mapper.Map<AutenticacaoDto>(viewModel);
            _servico.Autenticar(autenticacaoDto, HttpContext.Session);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("sair")]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
