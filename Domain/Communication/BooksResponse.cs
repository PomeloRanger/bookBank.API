using bookBank.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Communication
{
    public class BooksResponse : BaseResponse
    {
        public IEnumerable<Book> Book { get; private set; }

        public BooksResponse(bool success, string message, IEnumerable<Book> book) : base(success, message)
        {
            this.Book = book;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Authenticate response"></param>
        /// <returns>Response.</returns>
        public BooksResponse(IEnumerable<Book> book) : this(true, string.Empty, book)
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
