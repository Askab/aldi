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

        public async Task<Loan> CreateLoan(LoanDto loanDto)
        {
            Loan loan = _unitOfWork.LoanRepository.CreateLoan(loanDto);
            await _unitOfWork.SaveChangesAsync();
            return loan;
        }

        public async Task<Loan> UpdateLoan(LoanDto loanDto)
        {
            Loan loan = _unitOfWork.LoanRepository.UpdateLoan(loanDto);
            await _unitOfWork.SaveChangesAsync();
            return loan;
        }

        public async Task<bool> DeleteLoan(LoanDto loanDto)
        {
            bool isDeleted = _unitOfWork.LoanRepository.DeleteLoan(loanDto);
            await _unitOfWork.SaveChangesAsync();
            return isDeleted;
        }
    }
}
