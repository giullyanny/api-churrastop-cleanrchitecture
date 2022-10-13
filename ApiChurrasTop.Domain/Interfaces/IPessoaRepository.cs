using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIChurrasTop.Domain.Entities;

namespace APIChurrasTop.Domain.Interfaces
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> GetAsync();
        Task<Pessoa> GetAsync(string cpf);
        Task<Pessoa> NovoAsync(Pessoa pessoa);
        Task<Pessoa> EditarAsync(Pessoa pessoa);
        Task<Pessoa> RemoverAsync(Pessoa pessoa);
    }
}