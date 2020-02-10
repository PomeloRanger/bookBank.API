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

        public async Task<Book> GetUserById(int id)
        {
            return await this.context.Books
                .Include(b => b.BookPublishers)
                    .ThenInclude(bp => bp.Publisher)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author).FirstOrDefaultAsync(i => i.BookID == id);
        }

        public async Task<IEnumerable<Book>> ListAsync()
        {
            return await this.context.Books
                .Include(b => b.BookPublishers)
                    .ThenInclude(bp => bp.Publisher)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .ToListAsync();
        }
    }
}
