using API_VT.Data;
using API_VT.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_VT.Services
{
    public class SetorService
    {
        private readonly DataContext _context;

        public SetorService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Setor>> FindAllAsync()
        {
            return await _context.Setores.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Setor> FindSetorById(int id)
        {
            return await _context.Setores.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
