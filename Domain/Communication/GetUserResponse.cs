using bookBank.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Communication
{
    public class GetUserResponse : BaseResponse
    {
        public User user { get; private set; }
        public GetUserResponse(bool success, string message, User user) : base(success, message)
        {
            this.user = user;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="user">Saved User.</param>
        /// <returns>Response.</returns>
        public GetUserResponse(User user) : this(true, string.Empty, user)
        {
        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public GetUserResponse(string message) : this(false, message, null)
        {
        }
    }
}
