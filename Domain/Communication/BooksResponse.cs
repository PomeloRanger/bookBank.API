using bookBank.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Communication
{
    public class BooksResponse : BaseResponse
    {
        public IEnumerable<Book> Books { get; private set; }

        public BooksResponse(bool success, string message, IEnumerable<Book> books) : base(success, message)
        {
            this.Books = books;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Books response"></param>
        /// <returns>Books Response.</returns>
        public BooksResponse(IEnumerable<Book> books) : this(true, string.Empty, books)
        {
        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public BooksResponse(string message) : this(false, message, null)
        {
        }
    }
}
