using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using RechartsAPI.Models;
using RechartsAPI.Repository;

namespace RechartsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetAtendimentoController : ControllerBase
    {
        // GET: api/motivodeschamada
        [HttpGet]
        public IActionResult GetMotivoChamadaData()
        {
            var parametros = new AtdParametroModel();

            parametros.DataInicio = new DateTime(DateTime.Now.Year, 1, 1);
            parametros.DataFim= new DateTime(DateTime.Now.Year, 12, 31);
            parametros.EmpresaId = 23;
            parametros.Servicos = new List<int> { 17, 13, 9, 15, 12 };


            // Chama o método que busca os dados
            var result = DBAtendimento.GetData(parametros);

            // Verifica se os dados foram retornados
            if (result == null || !result.Any())
            {
                // Caso não tenha nenhum dado, retorna um NoContent (204)
                return NoContent();
            }

            // Retorna os dados encontrados com Status 200 OK
            return Ok(result);
        }
    }
}
