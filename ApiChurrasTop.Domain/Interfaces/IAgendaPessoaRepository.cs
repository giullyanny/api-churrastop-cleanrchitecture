using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIChurrasTop.Domain.Entities;

namespace APIChurrasTop.Domain.Interfaces
{
    public interface IAgendaPessoaRepository
    {
        Task<List<AgendaPessoa>> GetAsync(Guid id);
        Task<List<AgendaPessoa>> GetAsync(DateTime dataAtual);
        Task NovoAsync(IEnumerable<AgendaPessoa> agendaPessoa);
        Task EditarAsync(IEnumerable<AgendaPessoa> agendaPessoa);
        Task RemoverAsync(IEnumerable<AgendaPessoa> agendaPessoa);
    }
}