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
    public class CategoryService : ICategoryServices
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<BooksResponse> GetBookByCategory(int id)
        {
            var result = await this.categoryRepository.GetCategoryById(id);
            if (result == null)
            {
                return new BooksResponse("Can't find books by that category ID");
            }
            return new BooksResponse(result);
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await this.categoryRepository.ListAsync();
        }
    }
}
