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
    [Route("v1/agenda")]
    public class Agenda : ControllerBase
    {
        private readonly IAgendaService _agendaService;

        public Agenda(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<string>> Get(Guid id)
        {
            try
            {
                AgendaDTO agendaDTO = await _agendaService.Get(id);

                return Ok(agendaDTO);
            }
            catch (Exception error)
            {
                //mensagem deve ser tratada
                return BadRequest(error);
            }
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<ActionResult<string>> add(AgendaAddDTO agenda)
        {
            try
            {

                AgendaDTO dto = (AgendaDTO)agenda;

                await _agendaService.Add(dto);

                return Ok("Cadastro salvo com sucesso!");
            }
            catch (Exception error)
            {
                //mensagem deve ser tratada
                return BadRequest(error.Message);
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public async Task<ActionResult<string>> atualizar(AgendaDTO agenda)
        {
            try
            {
                await _agendaService.Upd(agenda);

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
        public async Task<ActionResult<string>> remover(Guid agendaId)
        {
            try
            {
                await _agendaService.Rem(agendaId);

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