using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookBank.API.Domain.Services;
using bookBank.API.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using bookBank.API.Domain.Models;

namespace bookBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BundleController : ControllerBase
    {
        private readonly IBundleService bundleService;
        private readonly IMapper mapper;

        public BundleController(IBundleService bundleService, IMapper mapper)
        {
            this.bundleService = bundleService;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<BundleResource>> GetAllAsync()
        {
            var bundles = await this.bundleService.ListAsync();
            var resources = this.mapper.Map<IEnumerable<Bundle>, IEnumerable<BundleResource>>(bundles);
            return resources;
        }
    }
}