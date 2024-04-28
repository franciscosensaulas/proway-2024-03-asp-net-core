using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermercadoServicos.Dtos.Estantes;
using SupermercadoServicos.Interfaces;

namespace ProwayWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstanteController : ControllerBase
    {
        private readonly IEstanteServico _servico;
        private readonly IMapper _mapper;

        public EstanteController(IEstanteServico servico, IMapper mapper)
        {
            _servico = servico;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var estantes = _servico.ObterTodos();
            return Ok(estantes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var estante = _servico.ObterPorId(id);
            return Ok(estante);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EstanteCadastrarDto dto)
        {
            var id = _servico.Cadastrar(dto);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _servico.Apagar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] EstanteEditarDto dto)
        {
            _servico.Editar(dto);
            return Ok();
        }

    }
}
