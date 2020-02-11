using bookBank.API.Domain.Communication;
using bookBank.API.Domain.Repositories;
using bookBank.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository reviewRepository;
        private readonly IUnitOfWork unitOfWork;

        public ReviewService(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
        {
            this.reviewRepository = reviewRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ReviewsResponse> GetReviewsByBook(int id)
        {
            var result = await this.reviewRepository.GetReviewsByBook(id);
            if (result == null)
            {
                return new ReviewsResponse("No reviews were found");
            }
            return new ReviewsResponse(result);
        }
    }
}