using bookBank.API.Domain.Models;
using bookBank.API.Domain.Persistence.Contexts;
using bookBank.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Persistence.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Book>> GetBookByAuthor(int id)
        {
            return await this.context.Books
                .Include(b => b.BookPublishers)
                    .ThenInclude(bp => bp.Publisher)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Where(b => b.BookAuthors.Any(bc => bc.AuthorID == id))
                .ToListAsync();
        }

        public async Task<IEnumerable<Author>> ListAsync()
        {
            return await this.context.Authors
                    .Include(a => a.BookAuthors)
                        .ThenInclude(ba => ba.Author)
                    .ToListAsync();
        }
    }
}