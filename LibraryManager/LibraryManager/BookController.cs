using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Entities;
using LibraryManager.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ILibraryBank libraryBank1;

        public BookController(ILibraryBank libraryBank)
        {
            libraryBank1 = libraryBank;
        }

        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            List<Book> Books = libraryBank1.GetBooks();
            return Books;
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public Book Get(int id)
        {
            return libraryBank1.Get(id);
        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            libraryBank1.Add(book);
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}", Name = "Delete")]
        public int Delete(int id)
        {
            return libraryBank1.Delete(id);
        }

        // DELETE: api/Book/5
        [HttpPut("{id}", Name = "Put")]
        public int Put([FromBody] Book book)
        {
            return libraryBank1.Edit(book);
        }

    }
}
