using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;

namespace ALDIBookProject.Services.Interfaces
{
    public interface ILoanService
    {
        public Task<List<Loan>> ListAllLoans();

        public Task<Loan?> GetById(int id);

        public Loan CreateLoan(LoanDto loanDto);

        public Loan UpdateLoan(LoanDto loanDto);

        public bool DeleteLoan(LoanDto loanDto);
    }
}
