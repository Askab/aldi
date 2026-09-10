using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;
using ALDIBookProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ALDIBookProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        ILoanService _loanService;
        IBookService _bookService;
        IUserService _userService;

        public LoanController(
            ILoanService loanService,
            IBookService bookService,
            IUserService userService
        )
        {
            _loanService = loanService;
            _bookService = bookService;
            _userService = userService;
        }

        // GET: api/<LoanController>
        [HttpGet]
        public async Task<IEnumerable<Loan>> Get()
        {
            return await _loanService.ListAllLoans();
        }

        // GET api/<LoanController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loan?>> Get(Guid id)
        {
            Loan? loan = await _loanService.GetById(id);

            return loan == null ? NotFound() : Ok(loan);
        }

        public async Task<ActionResult<List<Loan>>> GetLoansByUserId(Guid userId)
        {
            List<Loan> loans = await _loanService.ListLoansByUserId(userId);
            return loans == null ? NotFound() : Ok(loans);
        }

        // POST api/<LoanController>
        [HttpPost]
        public async Task<ActionResult<Loan>> Create([FromBody] LoanDto loanDto)
        {
            //Check if there is a book with the given id
            Book? book = await _bookService.GetById(loanDto.BookId);

            if (book == null)
                return NotFound("Book not found!");
            else if (book.IsAvailable == false)
                return NotFound("Book is not available for loan!");

            //Check if there is a user with the given id
            User? user = await _userService.GetById(loanDto.UserId);
            
            if(user == null)
                return NotFound("User not found!");

            Loan loan = await _loanService.CreateLoan(loanDto);

            return loan == null ? BadRequest() : CreatedAtAction(nameof(Get), new { id = loan.Id }, loan);
        }

        // PUT api/<LoanController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Loan>> Update(Guid id, [FromBody] LoanDto loanDto)
        {
            //Check if there is a book with the given id
            Book? book = await _bookService.GetById(loanDto.BookId);

            if (book == null)
                return NotFound("Book not found!");

            //Check if there is a user with the given id
            User? user = await _userService.GetById(loanDto.UserId);

            if (user == null)
                return NotFound("User not found!");

            Loan? loan = await _loanService.UpdateLoan(id, loanDto);

            return loan == null ? NotFound() : Ok(loan);
        }

        // DELETE api/<LoanController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            bool isDeleted = await _loanService.DeleteLoan(new LoanDto { Id = id });

            return isDeleted == true ? Ok() : NotFound();
        }
    }
}
