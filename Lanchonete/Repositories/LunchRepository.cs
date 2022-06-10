using Lanchonete.Data;
using Lanchonete.Models;
using Lanchonete.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lanchonete.Repositories
{
    public class LunchRepository : ILunchRepository
    {
        private readonly AppDbContext _context;
        public LunchRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Lunch> Lunches => _context.Lunches.Include(c => c.Category);

        public IEnumerable<Lunch> FavoritesLunches => _context.Lunches.
                                   Where(l => l.IsFavoriteLouch)
                                  .Include(c => c.Category);

        public Lunch GetLunchById(int lunchId)
        {
            return _context.Lunches.FirstOrDefault(l => l.LuchId == lunchId);
        }
    }
}
