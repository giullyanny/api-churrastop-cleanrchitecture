using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiChurrasTop.Application.DTO;
using ApiChurrasTop.Application.Interfaces;
using APIChurrasTop.Domain.Entities;
using APIChurrasTop.Domain.Interfaces;
using AutoMapper;

namespace ApiChurrasTop.Application.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly IMapper _mapper;
        private readonly IAgendaRepository _repository;

        public AgendaService(IAgendaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AgendaDTO> Get(Guid id)
        {
            var pessoa = await _repository.GetAsync(id);

            return _mapper.Map<AgendaDTO>(pessoa);
        }

        public async Task Add(AgendaDTO AgendaDTO)
        {
            var agenda = _mapper.Map<Agenda>(AgendaDTO);

            await _repository.NovoAsync(agenda);
        }

        public async Task Upd(AgendaDTO agendaDTO)
        {
            var agenda = _mapper.Map<Agenda>(agendaDTO);

            await _repository.EditarAsync(agenda);
        }

        public async Task Rem(Guid id)
        {
            var pessoa = _repository.GetAsync(id).Result;

            await _repository.RemoverAsync(pessoa);
        }
    }
}