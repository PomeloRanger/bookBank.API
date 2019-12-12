using bookBank.API.Domain.Models;
using bookBank.API.Domain.Repositories;
using bookBank.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Services
{
    public class BundleService : IBundleService
    {
        private readonly IBundleRepository bundleRepository;

        public BundleService(IBundleRepository bundleRepository)
        {
            this.bundleRepository = bundleRepository;
        }

        public async Task<IEnumerable<Bundle>> ListAsync()
        {
            return await this.bundleRepository.ListAsync();
        }
    }
}
