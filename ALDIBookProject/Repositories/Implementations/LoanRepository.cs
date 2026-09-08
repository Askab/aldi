using ALDIBookProject.Contexts;
using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;
using ALDIBookProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ALDIBookProject.Repositories.Implementations
{
    public class LoanRepository : ILoanRepository
    {
        protected readonly BookDBContext _context;
        protected readonly DbSet<Loan> _set;

        public LoanRepository(BookDBContext context)
        {
            _context = context;
            _set = _context.Loans;
        }

        public async Task<List<Loan>> ListAllLoans()
        {
            return await _set.ToListAsync();
        }

        public async Task<Loan?> GetById(Guid id)
        {
            return await _set.FindAsync(id);
        }

        public Loan CreateLoan(LoanDto loanDto)
        {
            Loan loan = new () {
                Id = Guid.NewGuid(),
                UserId = loanDto.UserId,
                BookId = loanDto.BookId,
                LoanDate = loanDto.LoanDate,
                ReturnDate = loanDto.ReturnDate,
            };

            _set.Add(loan);

            return loan;
        }

        public async Task<Loan?> UpdateLoan(LoanDto loanDto)
        {
            Loan? loan = await _set.FindAsync(loanDto.Id);

            if (loan == null)
                return null;

            loan.BookId = loanDto.BookId;
            loan.UserId = loanDto.UserId;
            loan.LoanDate = loanDto.LoanDate;
            loan.ReturnDate = loanDto.ReturnDate;

            return loan;
        }

        public async Task<bool> DeleteLoan(LoanDto loanDto)
        {
            Loan? loan = await _set.FindAsync(loanDto.Id);

            if (loan == null)
                return false;

            _set.Remove(loan);

            return true;
        }
    }
}
