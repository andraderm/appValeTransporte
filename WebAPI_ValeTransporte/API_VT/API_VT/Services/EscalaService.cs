using API_VT.Data;
using API_VT.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_VT.Services
{
    public class EscalaService
    {
        private readonly DataContext _context;

        public EscalaService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Escala>> FindAllAsync()
        {
            return await _context.Escalas.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Escala> FindEscalaById(int id)
        {
            return await _context.Escalas.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
