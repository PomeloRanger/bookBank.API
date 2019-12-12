using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookBank.API.Domain.Models;
using bookBank.API.Domain.Services;
using bookBank.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace bookBank.API.Controllers
{
    [Route("api/[Controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BookResource>> GetAllAsync()
        {
            var books = await this.bookService.ListAsync();
            var resources = this.mapper.Map<IEnumerable<Book>, IEnumerable<BookResource>>(books);
            return resources;
        }
    }
}