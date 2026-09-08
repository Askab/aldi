using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;

namespace ALDIBookProject.Repositories.Interfaces
{
    public interface ILoanRepository
    {
        public Task<List<Loan>> ListAllLoans();

        public Task<Loan?> GetById(Guid id);

        public Loan CreateLoan(LoanDto loanDto);

        public Task<Loan?> UpdateLoan(Guid id, LoanDto loanDto);

        public Task<bool> DeleteLoan(LoanDto loanDto);
    }
}