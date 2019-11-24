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

        public async Task<IEnumerable<Publisher>> ListAsync()
        {
            return await this.context.Publishers.ToListAsync();
        }
    }
}
