using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;

namespace ALDIBookProject.Repositories.Interfaces
{
    public interface IBookRepository
    {
        public Task<List<Book>> ListAllBooks();

        public Task<Book?> GetById(Guid id);

        public Book CreateBook(BookDto bookDto);

        public Task<Book?> UpdateBook(Guid id, BookDto bookDto);

        public Task<Book?> UpdateBookAvailability(Guid id, bool isAvailable);

        public Task<bool> DeleteBook(BookDto bookDto);
    }
}