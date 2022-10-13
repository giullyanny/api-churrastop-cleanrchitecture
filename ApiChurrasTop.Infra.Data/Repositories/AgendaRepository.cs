using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIChurrasTop.Domain.Entities;
using APIChurrasTop.Domain.Interfaces;
using APIChurrasTop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace APIChurrasTop.Infra.Data.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        ApplicationDbContext _context;

        public AgendaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Agenda> GetAsync(Guid id)
        {
            return await _context.Agenda.FindAsync(id);
        }

        public async Task<List<Agenda>> GetAsync(DateTime dataAtual)
        {
            return await _context.Agenda.Where(x=> x.Data >= dataAtual).ToListAsync();
        }

        public async Task<Agenda> NovoAsync(Agenda agenda)
        {
            _context.Add(agenda);
            await _context.SaveChangesAsync();

            return agenda;
        }

        public async Task<Agenda> EditarAsync(Agenda agenda)
        {
            agenda.Update(agenda.Data, agenda.Descricao, agenda.Observacao, new HashSet<AgendaPessoa>());

            _context.Update(agenda);
            await _context.SaveChangesAsync();

            return agenda;
        }

        public async Task<Agenda> RemoverAsync(Agenda agenda)
        {
            _context.Remove(agenda);
            await _context.SaveChangesAsync();

            return agenda;
        }
    }
}