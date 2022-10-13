using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiChurrasTop.Application.DTO;
using ApiChurrasTop.Application.Interfaces;
using APIChurrasTop.Domain.Entities;
using APIChurrasTop.Domain.Interfaces;
using AutoMapper;
using ApiChurrasTop.Application.Type;

namespace ApiChurrasTop.Application.Services
{
    public class AgendaPessoaService : IAgendaPessoaService
    {
        private readonly IMapper _mapper;
        private readonly IAgendaPessoaRepository _repository;

        public AgendaPessoaService(IAgendaPessoaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task NovoAsync(IEnumerable<AgendaPessoaDTO> agendaPessoas)
        {
            var pessoas = _mapper.Map<IEnumerable<AgendaPessoa>>(agendaPessoas);

            await _repository.NovoAsync(pessoas);
        }

        public async Task EditarAsync(IEnumerable<AgendaPessoaDTO> agendaPessoas)
        {

            var pessoas = _mapper.Map<IEnumerable<AgendaPessoa>>(agendaPessoas);

            await _repository.EditarAsync(pessoas);
        }

        public async Task RemoverAsync(IEnumerable<AgendaPessoaDTO> agendaPessoas)
        {
            var pessoas = _mapper.Map<IEnumerable<AgendaPessoa>>(agendaPessoas);
            await _repository.RemoverAsync(pessoas);
        }

        public async Task<AgendaComPessoasTotaisDTO> GetAsync(Guid id)
        {
            List<AgendaPessoa> agendaPessoa = await _repository.GetAsync(id);

            Agenda agenda = ((agendaPessoa.Count > 0) ? agendaPessoa.ElementAt(0).Agenda : null);

            if (agenda == null) new AgendaComPessoasTotaisDTO();

            AgendaComPessoasTotaisDTO result = new AgendaComPessoasTotaisDTO
            {
                Id = agenda.Id,
                Data = agenda.Data,
                Descricao = agenda.Descricao,
                Observacao = agenda.Observacao,
                TotalPessoas = agenda.AgendaPessoas.Count,
                TotalValor = agenda.AgendaPessoas.Sum(x => x.Valor)
            };

            agendaPessoa.ForEach(x => result.PessoasDTO.Add(new PessoaComPessoaAgendaDTO
            {
                Id = x.Pessoa.Id,
                ComBebida = x.ComBebida,
                CPF = x.Pessoa.CPF,
                Email = x.Pessoa.Email,
                Nome = x.Pessoa.Nome,
                TelefoneCelular = x.Pessoa.TelefoneCelular,
                Valor = x.Valor
            }));


            return result;
        }

        public async Task<List<AgendaComTotaisDTO>> GetAsync(DateTime dataAtual)
        {
            List<AgendaPessoa> agendaPessoa = await _repository.GetAsync(dataAtual);

            List<AgendaComTotaisDTO> result = new List<AgendaComTotaisDTO>();

            agendaPessoa.ForEach(x =>
            {
                if (!result.Any(i => i.Id == x.AgendaId))
                {
                    result.Add(new AgendaComTotaisDTO
                    {
                        Id = x.AgendaId,
                        Data = x.Agenda.Data,
                        Descricao = x.Agenda.Descricao,
                        Observacao = x.Agenda.Observacao,
                        TotalPessoas = x.Agenda.AgendaPessoas.Count,
                        TotalValor = x.Agenda.AgendaPessoas.Sum(x => x.Valor)
                    });
                }
            });


            return result;
        }
    }
}