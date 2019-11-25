using bookBank.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> ListAsync();
    }
}
