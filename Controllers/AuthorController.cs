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
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService authorService;
        private readonly IMapper mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            this.authorService = authorService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByAuthor(int id)
        {
            var result = await this.authorService.GetBookByAuthor(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            //Mapped the value to autoMapped
            var resources = this.mapper.Map<IEnumerable<Book>, IEnumerable<BookResource>>(result.Book);
            return Ok(resources);
        }

        [HttpGet]
        public async Task<IEnumerable<AuthorResource>> GetAllAsync()
        {
            var authors = await this.authorService.ListAsync();
            var resources = this.mapper.Map<IEnumerable<Author>, IEnumerable<AuthorResource>>(authors);
            return resources;
        }
    }
}