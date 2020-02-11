# bookBank.API
Provides endpoint for bookBank system.

Important
======
Response are limited to 500 records per call
To load the next 500 record please implement the `$skip` operator.
```
https://localhost.com/Books$skip=500
```


## Endpoints
Field | Description
------|------------
`/Category` | Returns the list of item categories
`/Category/{id}` | Return list of books that belongs to the CategoryID
`/Bundle` | Returns array of books that are in a bundle
`/Author` | Returns list of authors
`/Author/{id}` | Return list of books that belongs to the AuthorID
`/Book` | Return list of books
`/Book/{id}` | Return a single book
`/Publisher` | Return list of publishers
`/Publisher/{id}` | Return list of books that belongs to the PublisherID
`/Review/{id}` | Return list of reviews that belongs to the BookID