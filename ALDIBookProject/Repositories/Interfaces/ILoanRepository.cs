using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;

namespace ALDIBookProject.Repositories.Interfaces
{
    public interface ILoanRepository
    {
        public Task<List<Loan>> ListAllLoans();

        public Task<Loan?> GetById(Guid id);

        public Loan CreateLoan(LoanDto loanDto);

        public Loan UpdateLoan(LoanDto loanDto);

        public bool DeleteLoan(LoanDto loanDto);
    }
}