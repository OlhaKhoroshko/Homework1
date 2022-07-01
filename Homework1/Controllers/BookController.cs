using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Homework1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private static List<Book> Books { get; set; }
        static BookController()
        {
            Books = new List<Book>
                    {
                        new Book
                        {
                            ID = 1,
                            Name = "C# для профессионалов. Тонкости программирования.",
                            Autor = "Джон Скит"
                        }
                    };
        }
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void Create(Book book)
        {
            book.ID = Books.Select(x => x.ID).Max() + 1;
            Books.Add(book);
        }

        [HttpPut("{id}")]
        public void Update(int id, Book book)
        {
            Books[id] = book;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Books.Remove(Books[id]);
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return Books;
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            return Books.FirstOrDefault(x => x.ID == id);
        }
    }
}
