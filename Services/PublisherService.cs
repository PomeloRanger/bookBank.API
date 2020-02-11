using bookBank.API.Domain.Communication;
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

        public async Task<BooksResponse> GetBookByPublisher(int id)
        {
            var result = await this.publisherRepository.GetBookByPublisher(id);
            if (result == null)
            {
                return new BooksResponse("Can't find books by that Publisher ID");
            }
            return new BooksResponse(result);
        }

        public async Task<IEnumerable<Publisher>> ListAsync()
        {
            return await this.publisherRepository.ListAsync();
        }
    }
}