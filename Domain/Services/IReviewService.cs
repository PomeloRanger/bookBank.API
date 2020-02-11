using bookBank.API.Domain.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Services
{
    public interface IReviewService
    {
        Task<ReviewsResponse> GetReviewsByBook(int id);
    }
}
