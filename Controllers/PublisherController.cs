using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookBank.API.Domain.Models;
using bookBank.API.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using bookBank.API.Resources;

namespace bookBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService publisherService;
        private readonly IMapper mapper;

        public PublisherController(IPublisherService publisherService, IMapper mapper)
        {
            this.publisherService = publisherService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByPublisher(int id)
        {
            var result = await this.publisherService.GetBookByPublisher(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            //Mapped the value to autoMapped
            var resources = this.mapper.Map<IEnumerable<Book>, IEnumerable<BookResource>>(result.Book);
            return Ok(resources);
        }

        [HttpGet]
        public async Task<IEnumerable<PublisherResource>> GetAllAsync()
        {
            var publishers = await this.publisherService.ListAsync();
            var resources = this.mapper.Map<IEnumerable<Publisher>, IEnumerable<PublisherResource>>(publishers);
            return resources;
        }
    }
}