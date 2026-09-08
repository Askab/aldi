using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;

namespace ALDIBookProject.Repositories.Interfaces
{
    public interface IBookRepository
    {
        public Task<List<Book>> ListAllBooks();

        public Task<Book?> GetById(int id);

        public Book CreateBook(BookDto bookDto);

        public Book UpdateBook(BookDto bookDto);

        public bool DeleteBook(BookDto bookDto);
    }
}