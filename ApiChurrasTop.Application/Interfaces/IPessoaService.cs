using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiChurrasTop.Application.DTO;
using ApiChurrasTop.Application.Type;

namespace ApiChurrasTop.Application.Interfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<PessoaDTO>> Get();
        Task<PessoaDTO> Get(string id);
        Task Add(PessoaDTO pessoa);
        Task Upd(PessoaDTO pessoa);
        Task Rem(string cpf);
    }
}