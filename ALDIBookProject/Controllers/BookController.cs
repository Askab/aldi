using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;
using ALDIBookProject.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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

        // GET api/<BookController>/550e8400-e29b-41d4-a716-446655440000
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(Guid id)
        {
            Book? book = await _bookService.GetById(id);

            return book == null ? NotFound() : Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<ActionResult<Book>> Create([FromBody] BookDto bookDto)
        {
            Book book = await _bookService.CreateBook(bookDto);

            return book == null ? BadRequest() : CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        // PUT api/<BookController>/550e8400-e29b-41d4-a716-446655440000
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Update(Guid id, [FromBody] BookDto bookDto)
        {
            Book book = await _bookService.UpdateBook(bookDto);

            return Ok(book);
        }

        // DELETE api/<BookController>/550e8400-e29b-41d4-a716-446655440000
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            bool isDeleted = await _bookService.DeleteBook(new BookDto { Id = id });

            return isDeleted ? Ok(isDeleted) : NotFound();
        }
    }
}
