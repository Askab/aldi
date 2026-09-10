using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;
using ALDIBookProject.Repositories.Interfaces;
using ALDIBookProject.Services.Interfaces;
using System.ComponentModel;

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

        public async Task<List<Loan>> ListLoansByUserId(Guid userId)
        {
            return await _unitOfWork.LoanRepository.ListLoansByUserId(userId);
        }

        public async Task<Loan> CreateLoan(LoanDto loanDto)
        {
            Loan loan = _unitOfWork.LoanRepository.CreateLoan(loanDto);
            Book? book = await _unitOfWork.BookRepository.UpdateBookAvailability(loanDto.BookId, false);

            await _unitOfWork.SaveChangesAsync();

            return loan;
        }

        public async Task<Loan?> UpdateLoan(Guid id, LoanDto loanDto)
        {
            Loan? loan = await _unitOfWork.LoanRepository.UpdateLoan(id, loanDto);
            await _unitOfWork.SaveChangesAsync();
            return loan;
        }

        public async Task<bool> DeleteLoan(LoanDto loanDto)
        {
            bool isDeleted = await _unitOfWork.LoanRepository.DeleteLoan(loanDto);

            if (!isDeleted)
                return false;

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}