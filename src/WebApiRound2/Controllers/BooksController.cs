﻿using System;
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

        private ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db) {
            _db = db;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _db.Books.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _db.Books.First(b => b.Id == id);


            //or public IActionResult Get(int id){
            //var book = _db.Books.First(b => b.Id == id);
            //if (book != null)
            //{
            //    return Ok(book);
            //}
            //return HttpNotFound();
            //}

        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {


            if (!ModelState.IsValid)
            {
                _db.Books.Add(book);
                _db.SaveChanges();

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
                Book dbBook = _db.Books.First(b => b.Id == id);
                dbBook.Title = book.Title;
                dbBook.Author = book.Author;
                dbBook.PageCount = book.PageCount;
                dbBook.Genre = book.Genre;

                _db.SaveChanges();

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
            var dbBook = _db.Books.First(b => b.Id == id);

            if(dbBook != null)
            {
                _db.Books.Remove(dbBook);
                _db.SaveChanges();
            }
        }
    }
}
