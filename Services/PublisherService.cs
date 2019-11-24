using bookBank.API.Domain.Models;
using bookBank.API.Domain.Repositories;
using bookBank.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository publisherRepository;
        public PublisherService(IPublisherRepository publisherRepository)
        {
            this.publisherRepository = publisherRepository;
        }

        public async Task<IEnumerable<Publisher>> ListAsync()
        {
            return await this.publisherRepository.ListAsync();
        }
    }
}