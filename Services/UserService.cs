using bookBank.API.Domain.Communication;
using bookBank.API.Domain.Models;
using bookBank.API.Domain.Repositories;
using bookBank.API.Domain.Services;
using bookBank.API.Helpers;
using bookBank.API.Resources;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace bookBank.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly AppSettings appSettings;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
            this.appSettings = appSettings.Value;
        }

        public async Task<AuthenticationResponse> Authenticate(Authenticate authModel)
        {
            if (string.IsNullOrEmpty(authModel.Username))
            {
                return new AuthenticationResponse("Username cannot be empty");
            }
            else if (string.IsNullOrEmpty(authModel.Password))
            {
                return new AuthenticationResponse("Password cannot be empty");
            }
            else
            {
                var user =  await this.userRepository.Authenticate(authModel);
                if (user == null)
                {
                    return new AuthenticationResponse("Username or password is incorrect");
                }
                //Create authentication token.
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(this.appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserID.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                //By right should use AutoMapper but i don't want to blur the lies between them.
                AuthUserResource authUser = new AuthUserResource();
                authUser.UserID = user.UserID;
                authUser.Username = user.Username;
                authUser.FirstName = user.FirstName;
                authUser.Address = user.Address;
                authUser.PostalCode = user.PostalCode;
                authUser.LastName = user.LastName;
                authUser.Token = tokenString;

                return new AuthenticationResponse(authUser);
            }
        }

        public async Task<CreateUserResponse> CreateUserAsync(User user, string password)
        {
            if (this.userRepository.CheckUsernameExists(user.Username))
            {
                return new CreateUserResponse("Username already exists");
            }
            else if (string.IsNullOrEmpty(password))
            {
                return new CreateUserResponse("Password is required");
            }
            else if (string.IsNullOrEmpty(user.Address))
            {
                return new CreateUserResponse("Address is required");
            }
            else if (string.IsNullOrEmpty(user.FirstName))
            {
                return new CreateUserResponse("First name is required");
            }
            else if (string.IsNullOrEmpty(user.LastName))
            {
                return new CreateUserResponse("Last name is required");
            }
            else
            {
                try
                {

                    byte[] passwordHash, passwordSalt;
                    Security.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;

                    await this.userRepository.AddUserAsync(user);
                    await this.unitOfWork.CompleteAsync();

                    return new CreateUserResponse(user);

                }
                catch (Exception ex)
                {
                    return new CreateUserResponse($"An error occured when creating the user : {ex.Message}");
                }
            }
        }

        public async Task<GetUserResponse> GetUserById(int id)
        {
            var result = await this.userRepository.GetUserById(id);
            if (result == null)
            {
                return new GetUserResponse("User not found");
            }
            return new GetUserResponse(result);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await this.userRepository.ListAsync();
        }
    }
}
