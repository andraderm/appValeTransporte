using API_VT.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API_VT.Controllers
{
    [ApiController]
    [Route("vt/despesa")]
    public class DespesaController : Controller
    {
        private readonly DespesaService _dservice;

        public DespesaController(DespesaService dservice)
        {
            _dservice = dservice;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var despesas = await _dservice.FindAllAsync();
            return Ok(despesas);
        }

        [HttpGet("{dataInicial}/{dataFinal}")]
        public async Task<IActionResult> GetByData(DateTime dataInicial, DateTime dataFinal)
        {
            var despesa = await _dservice.FindDespesaByData(dataInicial, dataFinal);
            return Ok(despesa);
        }

        [HttpGet("df")]
        public async Task<IActionResult> GetDespesasFucionarios()
        {
            var despfunc = await _dservice.FindDespesasFuncionarios();
            return Ok(despfunc);
        }

        [HttpDelete("{dataInicial}/{dataFinal}")]
        public async Task<IActionResult> Delete(DateTime dataInicial, DateTime dataFinal)
        {
            await _dservice.RemoveAsync(dataInicial, dataFinal);
            return Ok(new { mensagem = "Deletado" });
        }

        [HttpPost("{dataInicial}/{dataFinal}")]
        public async Task<IActionResult> Post(DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                await _dservice.InsertAsync(dataInicial, dataFinal);
                return Ok();
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
