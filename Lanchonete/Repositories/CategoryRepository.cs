using Lanchonete.Data;
using Lanchonete.Models;
using Lanchonete.Repositories.Interfaces;

namespace Lanchonete.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context; 
        }

        public IEnumerable<Category> Categories => _context.Categories;
    }
}
