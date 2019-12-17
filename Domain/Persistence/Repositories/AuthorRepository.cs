﻿using bookBank.API.Domain.Models;
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

        public async Task<IEnumerable<Author>> ListAsync()
        {
            return await this.context.Authors
                    .Include(a => a.BookAuthors)
                        .ThenInclude(ba => ba.Author)
                    .ToListAsync();
        }
    }
}