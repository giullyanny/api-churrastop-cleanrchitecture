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
    public class AgendaPessoaRepository : IAgendaPessoaRepository
    {
        ApplicationDbContext _context;

        public AgendaPessoaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AgendaPessoa>> GetAsync(Guid id)
        {
            List<AgendaPessoa> agendaPessoa = await _context.AgendaPessoa
                .Include(i => i.Pessoa)
                .Include(i => i.Agenda)
                .Where(x => x.AgendaId == id)
                .ToListAsync();

            return agendaPessoa;
        }

        public async Task<List<AgendaPessoa>> GetAsync(DateTime dataAtual)
        {
            List<AgendaPessoa> agendaPessoa = await _context.AgendaPessoa
                .Include(i => i.Pessoa)
                .Include(i => i.Agenda)
                .Where(x => x.Agenda.Data >= dataAtual)
                .ToListAsync();

                

            return agendaPessoa;
        }

        public async Task EditarAsync(IEnumerable<AgendaPessoa> agendaPessoa)
        {
            _context.UpdateRange(agendaPessoa);
            await _context.SaveChangesAsync();
        }

        public async Task NovoAsync(IEnumerable<AgendaPessoa> agendaPessoa)
        {
            _context.AddRange(agendaPessoa);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(IEnumerable<AgendaPessoa> agendaPessoa)
        {
            _context.RemoveRange(agendaPessoa);
            await _context.SaveChangesAsync();
        }
    }
}