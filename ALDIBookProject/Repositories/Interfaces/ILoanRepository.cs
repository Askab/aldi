using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;

namespace ALDIBookProject.Repositories.Interfaces
{
    public interface ILoanRepository
    {
        public List<Loan> ListAllLoans();

        public Book CreateLoan(LoanDto loanDto);

        public Book UpdateLoan(LoanDto loanDto);

        public bool DeleteLoan(LoanDto loanDto);
    }
}