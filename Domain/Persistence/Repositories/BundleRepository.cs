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
    public class BundleRepository : BaseRepository, IBundleRepository
    {
        public BundleRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Bundle>> ListAsync()
        {
            return await this.context.Bundles
                .Include(b => b.BookBundles)
                    .ThenInclude(bb => bb.Book)
                        .ThenInclude(b => b.BookPublishers)
                            .ThenInclude(bp => bp.Publisher)
                .Include(b => b.BookBundles)
                    .ThenInclude(bb => bb.Book)
                        .ThenInclude(b => b.BookCategories)
                            .ThenInclude(bc => bc.Category)
                .ToListAsync();
        }
    }
}