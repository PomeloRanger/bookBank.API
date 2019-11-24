using bookBank.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> ListAsync();
    }
}
