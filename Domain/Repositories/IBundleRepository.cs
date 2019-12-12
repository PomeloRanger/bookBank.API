﻿using bookBank.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Repositories
{
    public interface IBundleRepository
    {
        Task<IEnumerable<Bundle>> ListAsync();
    }
}
