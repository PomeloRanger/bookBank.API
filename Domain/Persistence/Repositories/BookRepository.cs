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
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Book>> ListAsync()
        {
            return await this.context.Books
                .Include(p => p.BookPublishers)
                    .ThenInclude(ba => ba.Publisher)
                .Include(p => p.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .ToListAsync();
        }
    }
}
