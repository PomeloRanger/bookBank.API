﻿using bookBank.API.Domain.Communication;
using bookBank.API.Domain.Models;
using bookBank.API.Domain.Repositories;
using bookBank.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<BooksResponse> GetBookByAuthor(int id)
        {
            var result = await this.authorRepository.GetBookByAuthor(id);
            if (result == null)
            {
                return new BooksResponse("Can't find books by that Publisher ID");
            }
            return new BooksResponse(result);
        }

        public async Task<IEnumerable<Author>> ListAsync()
        {
            return await this.authorRepository.ListAsync();
        }
    }
}