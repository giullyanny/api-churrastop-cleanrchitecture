using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiChurrasTop.Application.DTO;
using ApiChurrasTop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIChurrasTop.Api.Controllers
{
    [ApiController]
    [Route("v1/agenda-pessoa")]
    public class AgendaPessoa : ControllerBase
    {
        private readonly IAgendaPessoaService _agendaService;

        public AgendaPessoa(IAgendaPessoaService agendaService)
        {
            _agendaService = agendaService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<string>> Get(Guid id)
        {
            try
            {
                AgendaComPessoasTotaisDTO agendaPessoaDTO = await _agendaService.GetAsync(id);

                return Ok(agendaPessoaDTO);
            }
            catch (Exception error)
            {
                //mensagem deve ser tratada
                return BadRequest(error);
            }
        }

        [HttpGet]
        [Route("get-all-partir-data-atual")]
        public async Task<ActionResult<string>> Get(DateTime dataAtual)
        {
            try
            {
                List<AgendaComTotaisDTO> agendaPessoaDTO = await _agendaService.GetAsync(dataAtual);

                return Ok(agendaPessoaDTO);
            }
            catch (Exception error)
            {
                //mensagem deve ser tratada
                return BadRequest(error);
            }
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<ActionResult<string>> add(List<AgendaPessoaAddDTO> agenda)
        {
            try
            {
                HashSet<AgendaPessoaDTO> dtos = new HashSet<AgendaPessoaDTO>();

                agenda.ForEach(ap => dtos.Add(((AgendaPessoaDTO)ap)));

                await _agendaService.NovoAsync(dtos);

                return Ok("Cadastro salvo com sucesso!");
            }
            catch (Exception error)
            {
                //mensagem deve ser tratada
                return BadRequest(error.Message);
            }
        }

        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult<string>> alterar(IEnumerable<AgendaPessoaDTO> agenda)
        {
            try
            {
                await _agendaService.EditarAsync(agenda);

                return Ok("Cadastro salvo com sucesso!");
            }
            catch (Exception error)
            {
                //mensagem deve ser tratada
                return BadRequest(error.Message);
            }
        }

        [HttpDelete]
        [Route("remover")]
        public async Task<ActionResult<string>> remover(IEnumerable<AgendaPessoaDTO> agendaPessoa)
        {
            try
            {
                await _agendaService.RemoverAsync(agendaPessoa);

                return Ok("Cadastro removido com sucesso!");
            }
            catch (Exception error)
            {
                //mensagem deve ser tratada
                return BadRequest(error.Message);
            }
        }
    }
}