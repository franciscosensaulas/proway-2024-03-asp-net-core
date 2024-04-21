using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProwayWebMvc.Models.Estantes;
using SupermercadoServicos.Dtos.Estantes;
using SupermercadoServicos.Interfaces;

namespace ProwayWebMvc.Controllers
{
    [Route("estante")]
    public class EstanteController : Controller
    {
        private readonly IEstanteServico _estanteServico;
        private readonly IMapper _mapper;

        public EstanteController(IEstanteServico estanteServico, IMapper mapper)
        {
            _estanteServico = estanteServico;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var estanteDtos = _estanteServico.ObterTodos();
            var viewModels = _mapper.Map<List<EstanteIndexViewModel>>(estanteDtos);
            return View(viewModels);
        }

        [HttpGet("novo")]
        public IActionResult Novo()
        {
            var viewModel = new EstanteCadastrarViewModel();

            return View(viewModel);
        }

        [HttpPost("novo")]
        public IActionResult Create([FromForm] EstanteCadastrarViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Novo", viewModel);

            var dto = _mapper.Map<EstanteCadastrarDto>(viewModel);
            var id = _estanteServico.Cadastrar(dto);

            return RedirectToAction("Index");
        }

        [HttpGet("apagar")]
        public IActionResult Apagar([FromQuery] int id)
        {
            _estanteServico.Apagar(id);

            return RedirectToAction("Index");
        }

        [HttpGet("editar")]
        public IActionResult Editar([FromQuery] int id)
        {
            var estanteDto = _estanteServico.ObterPorId(id);

            var viewModel = _mapper.Map<EstanteEditarViewModel>(estanteDto);
            return View(viewModel);
        }

        [HttpPost("editar")]
        public IActionResult Update([FromForm] EstanteEditarViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Editar", viewModel);

            var estanteEditarDto = _mapper.Map<EstanteEditarDto>(viewModel);

            _estanteServico.Editar(estanteEditarDto);

            return RedirectToAction("Index");
        }
    }
}
