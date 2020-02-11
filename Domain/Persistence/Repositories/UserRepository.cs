using bookBank.API.Domain.Models;
using bookBank.API.Domain.Persistence.Contexts;
using bookBank.API.Domain.Repositories;
using bookBank.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace bookBank.API.Domain.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddUserAsync(User user)
        {
            await this.context.Users.AddAsync(user);
        }

        public bool CheckUsernameExists(string username)
        {
            if (context.Users.Any(x => x.Username == username))
            {
                return true;
            }
            return false;
        }


        public async Task<User> Authenticate(Authenticate authModel)
        {
            var user = await context.Users.SingleOrDefaultAsync(x => x.Username == authModel.Username);
            if (user == null)
            {
                return null;
            }
            else if (!Security.VerifyPasswordHash(authModel.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }

        public Task<IEnumerable<User>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(int id)
        {
            return await context.Users.FindAsync(id);
        }
    }
}