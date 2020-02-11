using bookBank.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Communication
{
    public class ReviewsResponse : BaseResponse
    {
        public IEnumerable<Review> Reviews { get; set; }
        public ReviewsResponse(bool success, string message, IEnumerable<Review> reviews) : base(success, message)
        {
            this.Reviews = reviews;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="reviews"></param>
        /// <returns>Reviews Response.</returns>
        public ReviewsResponse(IEnumerable<Review> reviews) : this(true, string.Empty, reviews)
        {
        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ReviewsResponse(string message) : this(false, message, null)
        {
        }
    }
}
