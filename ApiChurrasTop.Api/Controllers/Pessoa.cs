using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiChurrasTop.Application.DTO;
using ApiChurrasTop.Application.Interfaces;
using ApiChurrasTop.Application.Type;
using Microsoft.AspNetCore.Mvc;

namespace APIChurrasTop.Api.Controllers
{
    [ApiController]
    [Route("v1/pessoa")]
    public class Pessoa : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public Pessoa(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<string>> Get()
        {
            try
            {
                IEnumerable<PessoaDTO> pessoaDTO = await _pessoaService.Get();

                return Ok(pessoaDTO);
            }
            catch (Exception error)
            {
                //mensagem deve ser tratada
                return BadRequest(error);
            }
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<string>> Get(string cpf)
        {
            try
            {
                PessoaDTO pessoaDTO = await _pessoaService.Get(cpf);

                return Ok(pessoaDTO);
            }
            catch (Exception error)
            {
                //mensagem deve ser tratada
                return BadRequest(error);
            }
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<ActionResult<string>> add(PessoaAddDTO pessoa)
        {
            try
            {
                PessoaDTO dto = (PessoaDTO)pessoa;

                await _pessoaService.Add(dto);

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
        public async Task<ActionResult<string>> atualizar(PessoaDTO pessoa)
        {
            try
            {
                await _pessoaService.Upd(pessoa);

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
        public async Task<ActionResult<string>> remover(string cpf)
        {
            try
            {
                await _pessoaService.Rem(cpf);

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