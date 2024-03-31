using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProwayWebMvc.Models.Produtos;
using SupermercadoServicos.Dtos.Categorias;
using SupermercadoServicos.Dtos.Produtos;
using SupermercadoServicos.Interfaces;
using SupermercadoServicos.Servicos;

namespace ProwayWebMvc.Controllers
{
    [Route("produto")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoServico _produtoServico;
        private readonly ICategoriaServico _categoriaServico;

        public ProdutoController(
            IProdutoServico produtoServico,
            ICategoriaServico categoriaServico)
        {
            _produtoServico = produtoServico;
            _categoriaServico = categoriaServico;
        }

        public IActionResult Index()
        {
            var produtoDtos = _produtoServico.ObterTodos();
            var produtoIndexViewModels = ProdutoIndexViewModel.ConstruirCom(produtoDtos);

            return View(produtoIndexViewModels);
        }

        [HttpGet("novo")]
        public IActionResult Cadastrar()
        {
            PreencherCategoriasViewBag();

            var produtoCadastrarViewModel = new ProdutoCadastrarViewModel();
            return View(produtoCadastrarViewModel);
        }

        [HttpPost("novo")]
        public IActionResult Cadastrar([FromForm] ProdutoCadastrarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                PreencherCategoriasViewBag();
                return View(viewModel);
            }

            var produtoDto = new ProdutoCadastrarDto
            {
                Nome = viewModel.Nome,
                CategoriaId = viewModel.CategoriaId.GetValueOrDefault(),
                PrecoUnitario = viewModel.PrecoUnitario.GetValueOrDefault(),
                DataVencimento = viewModel.DataVencimento.GetValueOrDefault(),
                Observacao = viewModel.Observacao
            };
            var id = _produtoServico.Cadastrar(produtoDto);

            return RedirectToActionPreserveMethod("Index");
        }

        [HttpGet("apagar")]
        public IActionResult Apagar([FromQuery]int id)
        {
            _produtoServico.Apagar(id);
            return RedirectToAction(nameof(Index));
        }

        private void PreencherCategoriasViewBag()
        {
            var categoriaDtos = _categoriaServico.ObterTodos();
            ViewBag.CategoriaDtos = ConstruirSelectListItemDasCategorias(categoriaDtos);
        }

        private List<SelectListItem> ConstruirSelectListItemDasCategorias(
            List<CategoriaDto> categoriaDtos)
        {
            var items = new List<SelectListItem>();
            foreach (var dto in categoriaDtos)
                items.Add(new SelectListItem(dto.Nome, dto.Id.ToString()));
            return items;
        }
    }
}
