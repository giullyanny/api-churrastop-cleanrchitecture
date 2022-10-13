using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiChurrasTop.Application.DTO;

namespace ApiChurrasTop.Application.Interfaces
{
    public interface IAgendaService
    {
        Task<AgendaDTO> Get(Guid id);
        Task Add(AgendaDTO pessoa);
        Task Upd(AgendaDTO pessoa);
        Task Rem(Guid id);
    }
}