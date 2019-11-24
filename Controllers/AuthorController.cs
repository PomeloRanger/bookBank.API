using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookBank.API.Domain.Models;
using bookBank.API.Domain.Services;
using bookBank.API.Resources;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<IEnumerable<AuthorResource>> GetAllAsync()
        {
            var authors = await this.authorService.ListAsync();
            var resources = this.mapper.Map<IEnumerable<Author>, IEnumerable<AuthorResource>>(authors);
            return resources;
        }
    }
}