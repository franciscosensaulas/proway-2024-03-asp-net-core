using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;

namespace ProwayWebMvc.Controllers
{
    [Route("calculadora")]
    public class CalculadoraController : Controller
    {
        // Action
        [HttpGet]
        public IActionResult Index()
        {
            List<UserDetails> persons = new List<UserDetails>()
            {
                new UserDetails() {ID="1001", Name="ABCD", City ="City1", Country="USA"},
                new UserDetails() {ID="1002", Name="PQRS", City ="City2", Country="INDIA"},
                new UserDetails() {ID="1003", Name="XYZZ", City ="City3", Country="CHINA"},
                new UserDetails() {ID="1004", Name="LMNO", City ="City4", Country="UK"},
           };

            // Lets converts our object data to Datatable for a simplified logic.
            // Datatable is most easy way to deal with complex datatypes for easy reading and formatting.

            DataTable table = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(persons), (typeof(DataTable)));
            var memoryStream = new MemoryStream();

            using (var fs = new FileStream("Result.xlsx", FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Sheet1");

                List<String> columns = new List<string>();
                IRow row = excelSheet.CreateRow(0);
                int columnIndex = 0;

                foreach (System.Data.DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);
                    row.CreateCell(columnIndex).SetCellValue(column.ColumnName);
                    columnIndex++;
                }

                int rowIndex = 1;
                foreach (DataRow dsrow in table.Rows)
                {
                    row = excelSheet.CreateRow(rowIndex);
                    int cellIndex = 0;
                    foreach (String col in columns)
                    {
                        row.CreateCell(cellIndex).SetCellValue(dsrow[col].ToString());
                        cellIndex++;
                    }

                    rowIndex++;
                }
                workbook.Write(fs);
            }
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
