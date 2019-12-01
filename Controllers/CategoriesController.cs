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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices categoryServices;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryServices categoryServices, IMapper mapper)
        {
            this.categoryServices = categoryServices;
            this.mapper = mapper;
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