using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApiRound2.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiRound2.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        static List<Book> _books = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                Title = "Lord of the Rings",
                Author = "J.R.R. Tolkien",
                PageCount = 1329,
                Genre = "High Fantasy"
            },

            new Book()
            {
                Id = 2,
                Title = "Great Gatsby",
                Author = "F. Scott Fitzgerald",
                PageCount = 192,
                Genre = "Modernist Fiction"
            },

            new Book()
            {
                Id = 3,
                Title= "To Kill a Mockingbird",
                Author = "Harper Lee",
                PageCount = 281,
                Genre = "Modernist Fiction"
            }
        };
        

        // GET: api/values
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _books;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _books.First(b => b.Id == id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {

            if (ModelState.IsValid)
            {
                //another method to generate id for book
                book.Id = _books.Max(b => b.Id) + 1;
                _books.Add(book);

                return Ok();
            }
            else
            {
                return HttpBadRequest(ModelState);
            }
        }


        [HttpGet("search/{searchTerms}")]
        public void Search(string searchTerms) { }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Book book)
        {
            if (ModelState.IsValid)
            {
                Book dbBook = _books.First(b => b.Id == id);
                dbBook.Title = book.Title;
                dbBook.Author = book.Author;
                dbBook.PageCount = book.PageCount;
                dbBook.Genre = book.Genre;

                return Ok();
            }
            else
            {
                return HttpBadRequest(ModelState);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
