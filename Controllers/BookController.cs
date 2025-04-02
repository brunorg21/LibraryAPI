using LibraryAPI.Controllers.Communication.Requests;
using LibraryAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static  ConcurrentBag<Book> _books = new ConcurrentBag<Book>();
        private static int _nextId = 1; 

        [HttpGet]
        [ProducesResponseType(typeof(List<Book>),StatusCodes.Status200OK)]
        public IActionResult Get()
        {
        
            return Ok(_books);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Create([FromBody] RequestCreateUserJson book)
        {
            var createdBook = new Book()
            {
                Id = _nextId++,
                Amount = book.Amount,
                Author = book.Author,
                Gender = book.Gender,
                Price = book.Price,
                Title = book.Title
            };

            _books.Add(createdBook);

            return Created("",createdBook);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update([FromBody] RequestCreateUserJson bookToUpdate, [FromRoute] int id)
        {
            Book book1 = _books.FirstOrDefault(x => x.Id == id);

            if(book1 == null)
            {
                return NotFound();
            }

            book1.Gender = bookToUpdate.Gender;
            book1.Price = bookToUpdate.Price;
            book1.Title = bookToUpdate.Title;
            book1.Author = bookToUpdate.Author;
            book1.Amount = bookToUpdate.Amount;
             

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] int id)
        {
            var newBooks = _books.Where(book => book.Id != id);

            _books = new ConcurrentBag<Book>(newBooks);

            return NoContent();
        }
    }
}
