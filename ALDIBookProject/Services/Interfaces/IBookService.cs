using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;

namespace ALDIBookProject.Services.Interfaces
{
    public interface IBookService
    {
        public Task<List<Book>> ListAllBooks();

        public Task<Book?> GetById(Guid id);

        public Task<Book> CreateBook(BookDto bookDto);

        public Task<Book?> UpdateBook(BookDto bookDto);

        public Task<bool> DeleteBook(BookDto bookDto);
    }
}
