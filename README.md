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
`/Categories` | Returns the list of item categories
`/Bundle` | Returns list of items that are currently discounted in a bundle
`/Author` | Returns list of authors
`/Books` | Return list of books
