using API_VT.Models.Entities;
using API_VT.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API_VT.Controllers
{
    [ApiController]
    [Route("vt/funcionario")]
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioService _fservice;

        public FuncionarioController(FuncionarioService fservice)
        {
            _fservice = fservice;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var funcionarios = await _fservice.FindAllAsync();
                return Ok(funcionarios);
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{funcionarioId}")]
        public async Task<IActionResult> GetFuncionarioById(int funcionarioId)
        {
            try
            {
                var funcionario = await _fservice.FindFuncionarioById(funcionarioId);
                return Ok(funcionario);
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("setor/{nomeSetor}")]
        public async Task<IActionResult> GetFuncionarioBySetor(string nomeSetor)
        {
            try
            {
                var funcionario = await _fservice.FindFuncionarioBySetor(nomeSetor);
                return Ok(funcionario);
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("escala/{tipoEscala}")]
        public async Task<IActionResult> GetFuncionarioByEscala(string tipoEscala)
        {
            try
            {
                var funcionario = await _fservice.FindFuncionarioByEscala(tipoEscala);
                return Ok(funcionario);
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Funcionario funcionario)
        {
            try
            {
                await _fservice.InsertAsync(funcionario);
                return Ok(funcionario);
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{funcionarioId}")]
        public async Task<IActionResult> Put(int funcionarioId, Funcionario model)
        {
            await _fservice.UpdateAsync(funcionarioId, model);
            return Ok(model);
        }

        [HttpDelete("{funcionarioId}")]
        public async Task<IActionResult> Delete(int funcionarioId)
        {
            await _fservice.RemoveAsync(funcionarioId);
            return Ok(new { mensagem = "Deletado" });
        }
    }
}
