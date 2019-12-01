using bookBank.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> ListAsync();
    }
}
