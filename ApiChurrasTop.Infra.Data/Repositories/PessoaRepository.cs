using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIChurrasTop.Domain.Entities;
using APIChurrasTop.Domain.Interfaces;
using APIChurrasTop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace APIChurrasTop.Infra.Data.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        ApplicationDbContext _context;

        public PessoaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pessoa> EditarAsync(Pessoa pessoa)
        {
            _context.Update(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        }

        public async Task<Pessoa> GetAsync(string cpf) => await _context.Pessoa.FirstOrDefaultAsync(x => x.CPF == cpf);

        public async Task<IEnumerable<Pessoa>> GetAsync() => await _context.Pessoa.ToListAsync();

        public async Task<Pessoa> NovoAsync(Pessoa pessoa)
        {
            _context.Add(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        }

        public async Task<Pessoa> RemoverAsync(Pessoa pessoa)
        {
            _context.Remove(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        }
    }
}