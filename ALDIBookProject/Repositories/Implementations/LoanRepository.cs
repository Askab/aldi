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

        public async Task<Loan?> GetById(int id)
        {
            return await _set.FindAsync(id);
        }

        public Loan CreateLoan(LoanDto loanDto)
        {
            Loan loan = new () {
                Id = loanDto.Id,
                User = loanDto.User,
                Book = loanDto.Book,
                LoanDate = loanDto.LoanDate,
                ReturnDate = loanDto.ReturnDate,
            };

            _set.Add(loan);

            return loan;
        }

        public Loan UpdateLoan(LoanDto loanDto)
        {
            Loan loan = new()
            {
                Id = loanDto.Id,
                User = loanDto.User,
                Book = loanDto.Book,
                LoanDate = loanDto.LoanDate,
                ReturnDate = loanDto.ReturnDate,
            };

            _set.Update(loan);

            return loan;
        }

        public bool DeleteLoan(LoanDto loanDto)
        {
            Loan loan = new()
            {
                Id = loanDto.Id,
                User = loanDto.User,
                Book = loanDto.Book,
                LoanDate = loanDto.LoanDate,
                ReturnDate = loanDto.ReturnDate,
            };

            _set.Remove(loan);

            Loan? result = _set.Find(loan.Id);

            return result == null;
        }
    }
}
