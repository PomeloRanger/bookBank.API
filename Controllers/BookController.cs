using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookBank.API.Domain.Models;
using bookBank.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace bookBank.API.Controllers
{
    [Route("api/[Controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var Books = await this.bookService.ListAsync();
            return Books;
        }
    }
}