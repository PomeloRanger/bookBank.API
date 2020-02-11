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
    public class PublisherRepository : BaseRepository, IPublisherRepository
    {
        public PublisherRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Book>> GetBookByPublisher(int id)
        {
            return await this.context.Books
                .Include(b => b.BookPublishers)
                    .ThenInclude(bp => bp.Publisher)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Where(b => b.BookPublishers.Any(bp => bp.PublisherID == id))
                .ToListAsync();
        }

        public async Task<IEnumerable<Publisher>> ListAsync()
        {
            return await this.context.Publishers
                .Include(p => p.BookPublishers)
                    .ThenInclude(bp => bp.Book)
                .ToListAsync();
        }
    }
}