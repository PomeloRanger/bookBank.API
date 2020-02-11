using bookBank.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task<User> Authenticate(Authenticate authModel);
        Task<User> GetUserById(int id);
        Task AddUserAsync(User user);
        bool CheckUsernameExists(string username);
    }
}