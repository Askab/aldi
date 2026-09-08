using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;

namespace ALDIBookProject.Services.Interfaces
{
    public interface ILoanService
    {
        public Task<List<Loan>> ListAllLoans();

        public Task<Loan?> GetById(Guid id);

        public Task<Loan> CreateLoan(LoanDto loanDto);

        public Task<Loan?> UpdateLoan(LoanDto loanDto);

        public Task<bool> DeleteLoan(LoanDto loanDto);
    }
}
