using bookBank.API.Domain.Communication;
using bookBank.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();

        Task<CreateUserResponse> CreateUserAsync(User user, string password);

        Task<GetUserResponse> GetUserById(int id);

        Task<AuthenticationResponse> Authenticate(Authenticate authModel);
    }
}
