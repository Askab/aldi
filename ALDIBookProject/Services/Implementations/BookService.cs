using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;
using ALDIBookProject.Repositories.Interfaces;
using ALDIBookProject.Services.Interfaces;

namespace ALDIBookProject.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Book>> ListAllBooks()
        {
            return _unitOfWork.BookRepository.ListAllBooks();
        }

        public Task<Book?> GetById(Guid id)
        {
            return _unitOfWork.BookRepository.GetById(id);
        }

        public async Task<Book> CreateBook(BookDto bookDto)
        {
            Book book = _unitOfWork.BookRepository.CreateBook(bookDto);
            await _unitOfWork.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBook(BookDto bookDto)
        {
            Book book = _unitOfWork.BookRepository.UpdateBook(bookDto);
            await _unitOfWork.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBook(BookDto bookDto)
        {
            bool isDeleted = _unitOfWork.BookRepository.DeleteBook(bookDto);
            await _unitOfWork.SaveChangesAsync();
            return isDeleted;
        }
    }
}
