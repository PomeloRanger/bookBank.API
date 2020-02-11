using bookBank.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Communication
{
    public class BookResponse : BaseResponse
    {
        public Book Book { get; private set; }

        public BookResponse(bool success, string message, Book book) : base(success, message)
        {
            this.Book = book;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Authenticate response"></param>
        /// <returns>Response.</returns>
        public BookResponse(Book book) : this(true, string.Empty, book)
        {
        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public BookResponse(string message) : this(false, message, null)
        {
        }
    }
}
