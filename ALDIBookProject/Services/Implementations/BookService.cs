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

        public Task<Book?> GetById(int id)
        {
            return _unitOfWork.BookRepository.GetById(id);
        }

        public Book CreateBook(BookDto bookDto)
        {
            return _unitOfWork.BookRepository.CreateBook(bookDto);
        }

        public Book UpdateBook(BookDto bookDto)
        {
            return _unitOfWork.BookRepository.UpdateBook(bookDto);
        }

        public bool DeleteBook(BookDto bookDto)
        {
            return _unitOfWork.BookRepository.DeleteBook(bookDto);
        }
    }
}
