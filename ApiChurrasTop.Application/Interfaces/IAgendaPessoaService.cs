using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiChurrasTop.Application.DTO;

namespace ApiChurrasTop.Application.Interfaces
{
    public interface IAgendaPessoaService
    {
        Task<AgendaComPessoasTotaisDTO> GetAsync(Guid id);
        Task<List<AgendaComTotaisDTO>> GetAsync(DateTime dataAtual);
        Task NovoAsync(IEnumerable<AgendaPessoaDTO> agendaPessoa);
        Task EditarAsync(IEnumerable<AgendaPessoaDTO> agendaPessoa);
        Task RemoverAsync(IEnumerable<AgendaPessoaDTO> agendaPessoas);
    }
}