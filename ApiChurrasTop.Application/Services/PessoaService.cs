using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiChurrasTop.Application.DTO;
using ApiChurrasTop.Application.Interfaces;
using ApiChurrasTop.Application.Type;
using APIChurrasTop.Domain.Entities;
using APIChurrasTop.Domain.Interfaces;
using AutoMapper;

namespace ApiChurrasTop.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IMapper _mapper;
        private readonly IPessoaRepository _repository;

        public PessoaService(IPessoaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PessoaDTO>> Get()
        {
            var pessoas = await _repository.GetAsync();

            return _mapper.Map<IEnumerable<PessoaDTO>>(pessoas);
        }

        public async Task<PessoaDTO> Get(string cpf)
        {
            var pessoa = await _repository.GetAsync(cpf);

            return _mapper.Map<PessoaDTO>(pessoa);
        }

        public async Task Add(PessoaDTO pessoaDTO)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);

            await _repository.NovoAsync(pessoa);
        }

        public async Task Upd(PessoaDTO pessoaDTO)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);

            await _repository.EditarAsync(pessoa);
        }

        public async Task Rem(string cpf)
        {
            var pessoa = _repository.GetAsync(cpf).Result;

            await _repository.RemoverAsync(pessoa);
        }
    }
}