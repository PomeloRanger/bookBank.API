using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookBank.API.Domain.Communication;
using bookBank.API.Domain.Models;

namespace bookBank.API.Domain.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> ListAsync();
        Task<BookResponse> GetBookById(int id);
    }
}