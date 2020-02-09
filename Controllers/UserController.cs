using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookBank.API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using bookBank.API.Domain.Services;
using bookBank.API.Resources;
using bookBank.API.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using bookBank.API.Domain.Models;

namespace bookBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Authenticate resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var result = await this.userService.Authenticate(resource);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.User);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]Register resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            //Maps register model to user model
            var user = this.mapper.Map<Register, User>(resource);
            //Since there is no password in the user model. We must pass password to the CreateUserAsync class
            var result = await this.userService.CreateUserAsync(user, resource.Password);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            //Maps the user returned so it's has removed all the hash password or useless information
            //TODO : Make it churn out AccessToken for now we just return a success code.
            //var userResource = this.mapper.Map<User, UserResource>(user);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await this.userService.GetUserById(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            //Mapped the value to autoMapped
            var userResource = this.mapper.Map<User, UserResource>(result.user);
            return Ok(userResource);
        }
    }
}