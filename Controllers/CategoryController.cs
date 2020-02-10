using AutoMapper;
using bookBank.API.Domain.Models;
using bookBank.API.Domain.Services;
using bookBank.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bookBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices categoryServices;
        private readonly IMapper mapper;

        public CategoryController(ICategoryServices categoryServices, IMapper mapper)
        {
            this.categoryServices = categoryServices;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByCategory(int id)
        {
            var result = await this.categoryServices.GetBookByCategory(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            //Mapped the value to autoMapped
            var resources = this.mapper.Map<IEnumerable<Book>, IEnumerable<BookResource>>(result.Book);
            return Ok(resources);
        }


        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            var categories= await this.categoryServices.ListAsync();
            var resources = this.mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resources;
        }
    }
}