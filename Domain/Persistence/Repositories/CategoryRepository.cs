using bookBank.API.Domain.Models;
using bookBank.API.Domain.Persistence.Contexts;
using bookBank.API.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace bookBank.API.Domain.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Book>> GetCategoryById(int id)
        {
            return await this.context.Books
                .Include(b => b.BookPublishers)
                    .ThenInclude(bp => bp.Publisher)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Where(b => b.BookCategories.Any(bc => bc.CategoryID == id))
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await this.context.Categories
                    .Include(c => c.BookCategories)
                        .ThenInclude(bc => bc.Book)
                    .ToListAsync();
        }
    }
}
