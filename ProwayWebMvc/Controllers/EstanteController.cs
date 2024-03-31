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

        public EstanteController(IEstanteServico estanteServico)
        {
            _estanteServico = estanteServico;
        }

        public IActionResult Index()
        {
            var estanteDtos = _estanteServico.ObterTodos();
            var viewModels = new List<EstanteIndexViewModel>();
            foreach (var dto in estanteDtos)
            {
                var viewModel = new EstanteIndexViewModel
                {
                    Id = dto.Id,
                    Nome = dto.Nome,
                    Sigla = dto.Sigla
                };
                viewModels.Add(viewModel);
            }

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
            {
                return View("Novo", viewModel);
            }

            var dto = new EstanteCadastrarDto
            {
                Nome = viewModel.Nome,
                Sigla = viewModel.Sigla
            };
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

            var viewModel = new EstanteEditarViewModel
            {
                Id = estanteDto.Id,
                Nome = estanteDto.Nome,
                Sigla = estanteDto.Sigla
            };

            return View(viewModel);
        }

        [HttpPost("editar")]
        public IActionResult Update([FromForm] EstanteEditarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Editar", viewModel);
            }

            var estanteEditarDto = new EstanteEditarDto
            {
                Nome = viewModel.Nome,
                Sigla = viewModel.Sigla,
                Id = viewModel.Id
            };

            _estanteServico.Editar(estanteEditarDto);

            return RedirectToAction("Index");
        }
    }
}
