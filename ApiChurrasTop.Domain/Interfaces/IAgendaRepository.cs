using System.Collections.Concurrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIChurrasTop.Domain.Entities;

namespace APIChurrasTop.Domain.Interfaces
{
    public interface IAgendaRepository
    {
        Task<Agenda> GetAsync(Guid id);
        Task<Agenda> NovoAsync(Agenda agenda);
        Task<Agenda> EditarAsync(Agenda agenda);
        Task<Agenda> RemoverAsync(Agenda agenda);
    }
}