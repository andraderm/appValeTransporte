using API_VT.Data;
using API_VT.Models.Entities;
using API_VT.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_VT.Services
{
    public class FuncionarioService
    {
        private readonly DataContext _context;

        public FuncionarioService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Funcionario>> FindAllAsync()
        {
            return await _context.Funcionarios.Include(x => x.Escala).Include(x => x.Setor).ToListAsync();
        }

        public async Task<Funcionario> FindFuncionarioById(int id)
        {
            return await _context.Funcionarios.Include(x => x.Escala).Include(x => x.Setor).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Funcionario>> FindFuncionarioBySetor(string setor)
        {
            return await _context.Funcionarios.OrderBy(x => x.Nome).Where(x => x.Setor.Nome == setor).ToListAsync();
        }

        public async Task<List<Funcionario>> FindFuncionarioByEscala(string escala)
        {
            return await _context.Funcionarios.OrderBy(x => x.Nome).Where(x => x.Escala.EscalaTrabalho == escala).ToListAsync();
        }

        public async Task InsertAsync(Funcionario funcionario)
        {
            _context.Add(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int funcionarioId, Funcionario funcionario)
        {
            bool existe = await _context.Funcionarios.AnyAsync(x => x.Id == funcionarioId);
            if (!existe)
            {
                throw new NotFoundException("Objeto não encontrado");
            }
            try
            {
                _context.Update(funcionario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var funcionario = await _context.Funcionarios.FindAsync(id);
                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Não é possível deletar funcionario. Verifique as relações no banco de dados");
            }
        }
    }
}
