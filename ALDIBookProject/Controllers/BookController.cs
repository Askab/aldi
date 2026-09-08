using ALDIBookProject.Entities;
using ALDIBookProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ALDIBookProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookService.ListAllBooks().Result;
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book? Get(Guid id)
        {
            return _bookService.GetById(id).Result;
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
