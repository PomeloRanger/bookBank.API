using bookBank.API.Domain.Models;
using bookBank.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Communication
{
    public class AuthenticationResponse : BaseResponse
    {
        public AuthUserResource User { get; private set; }

        public AuthenticationResponse(bool success, string message, AuthUserResource user) : base(success, message)
        {
            this.User = user;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Authenticate response"></param>
        /// <returns>Response.</returns>
        public AuthenticationResponse(AuthUserResource user) : this(true, string.Empty, user)
        {
        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public AuthenticationResponse(string message) : this(false, message, null)
        {
        }
    }
}
