using bookBank.API.Domain.Communication;
using bookBank.API.Domain.Models;
using bookBank.API.Domain.Repositories;
using bookBank.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<BookResponse> GetBookById(int id)
        {
            var result = await this.bookRepository.GetUserById(id);
            if (result == null)
            {
                return new BookResponse("Book not found");
            }
            return new BookResponse(result);
        }

        public async Task<IEnumerable<Book>> ListAsync()
        {
            return await this.bookRepository.ListAsync();
        }
    }
}
