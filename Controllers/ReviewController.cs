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
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService reviewService;
        private readonly IMapper mapper;

        public ReviewController(IReviewService reviewService, IMapper mapper)
        {
            this.reviewService = reviewService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> GetReviewsByBook(int id)
        {
            var result = await this.reviewService.GetReviewsByBook(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            //Mapped the value to autoMapped
            var resources = this.mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(result.Reviews);
            return Ok(resources);
        }
    }
}