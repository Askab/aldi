using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;
using ALDIBookProject.Repositories.Interfaces;
using ALDIBookProject.Services.Interfaces;

namespace ALDIBookProject.Services.Implementations
{
    public class LoanService : ILoanService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Loan>> ListAllLoans()
        {
            return _unitOfWork.LoanRepository.ListAllLoans();
        }

        public Task<Loan?> GetById(Guid id)
        {
            return _unitOfWork.LoanRepository.GetById(id);
        }

        public Loan CreateLoan(LoanDto loanDto)
        {
            return _unitOfWork.LoanRepository.CreateLoan(loanDto);
        }

        public Loan UpdateLoan(LoanDto loanDto)
        {
            return _unitOfWork.LoanRepository.UpdateLoan(loanDto);
        }

        public bool DeleteLoan(LoanDto loanDto)
        {
            return _unitOfWork.LoanRepository.DeleteLoan(loanDto);
        }
    }
}
