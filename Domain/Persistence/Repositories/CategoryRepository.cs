using bookBank.API.Domain.Models;
using bookBank.API.Domain.Persistence.Contexts;
using bookBank.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace bookBank.API.Domain.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await this.context.Categories
                    .Include(p => p.BookCategories)
                        .ThenInclude(bp => bp.Book)
                    .ToListAsync();
        }
    }
}
