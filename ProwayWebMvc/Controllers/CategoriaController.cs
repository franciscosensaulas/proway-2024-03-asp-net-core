using Microsoft.AspNetCore.Mvc;
using ProwayWebMvc.Models.Categoria;
using SupermercadoServicos.Dtos.Categorias;
using SupermercadoServicos.Interfaces;
using SupermercadoServicos.Servicos;

namespace ProwayWebMvc.Controllers
{
    [Route("categoria")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaServico _categoriaServico;

        // ctor tab
        public CategoriaController()
        {
            _categoriaServico = new CategoriaServico();
        }

        public IActionResult Index()
        {
            var categoriaDtos = _categoriaServico.ObterTodos();
            var viewModels = new List<CategoriaIndexViewModel>();
            foreach (var dto in categoriaDtos)
            {
                var viewModel = new CategoriaIndexViewModel
                {
                    Id = dto.Id,
                    Nome = dto.Nome,
                };
                viewModels.Add(viewModel);
            }

            return View(viewModels);
        }

        [HttpGet("novo")]
        public IActionResult Novo()
        {
            var viewModel = new CategoriaCadastrarViewModel();

            return View(viewModel);
        }

        [HttpPost("novo")]
        public IActionResult Create([FromForm] CategoriaCadastrarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Novo", viewModel);
            }

            var dto = new CategoriaCadastrarDto
            {
                Nome = viewModel.Nome,
            };
            var id = _categoriaServico.Cadastrar(dto);

            return RedirectToAction("Index");
        }

        [HttpGet("apagar")]
        // FromForm => post
        // FromQuery => get => query url?name=Francisco, name é um query param
        public IActionResult Apagar([FromQuery] int id)
        {
            _categoriaServico.Apagar(id);

            return RedirectToAction("Index");
        }
            
        [HttpGet("editar")]
        public IActionResult Editar([FromQuery] int id)
        {
            var categoria = _categoriaServico.ObterPorId(id);

            var viewModel = new CategoriaEditarViewModel
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
            };

            return View(viewModel);
        }

        [HttpPost("editar")]
        public IActionResult Update([FromForm] CategoriaEditarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Editar", viewModel);
            }

            var categoriaEditarDto = new CategoriaEditarDto
            {
                Nome = viewModel.Nome,
                Id = viewModel.Id
            };

            _categoriaServico.Editar(categoriaEditarDto);

            return RedirectToAction("Index");
        }
    }
}
