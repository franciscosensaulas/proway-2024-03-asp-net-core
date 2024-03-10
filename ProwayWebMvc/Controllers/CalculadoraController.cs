using Microsoft.AspNetCore.Mvc;

namespace ProwayWebMvc.Controllers
{
    [Route("calculadora")]
    public class CalculadoraController : Controller
    {
        // Action
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("somar")]
        public IActionResult SomarCalculadora()
        {
            return View();
        }

        [HttpGet]
        [Route("subtrair")]
        public IActionResult SubtrairCalculadora()
        {
            return View("subtrair");
        }

        // calculadora/sum?numero01=...&numero02=...
        [HttpGet]
        [Route("sum")]
        public IActionResult Sum(
            [FromQuery] int numero01, // [FromQuery] irá pegar da URI o parâmetro
            [FromQuery] int numero02)
        {
            var x = numero01 / numero02;
            var soma = numero01 + numero02;
            return Ok($"Soma: {soma}");
        }

        [HttpGet]
        [Route("calcularImc")]
        public IActionResult CalcularImc()
        {
            return View();
        }

        [HttpGet]
        [Route("processImc")]
        public IActionResult ProcessImc([FromQuery] string nome,
            [FromQuery] int idade, [FromQuery] double altura, [FromQuery] double peso)
        {
            var imc = peso / (altura * altura);
            return Ok($"Nome: {nome} tem {idade} anos de vida com IMC de {imc}");
        }

        [HttpPost]
        [Route("processImc")]
        public IActionResult ProcessImcPost([FromForm] string nome,
            [FromForm] int idade, [FromForm] double altura, [FromForm] double peso)
        {
            var imc = peso / (altura * altura);
            return Ok($"Nome: {nome} tem {idade} anos de vida com IMC de {imc}");
        }

        // Solicitar nome, idade, altura, peso
        // nome
        // idade
        // altura
        // peso
        // Calcular imc

        // Criar action CalcularImc
        // Criar action ProcessImc
    }
}
