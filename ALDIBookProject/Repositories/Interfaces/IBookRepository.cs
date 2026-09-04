using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;

namespace ALDIBookProject.Repositories.Interfaces
{
    public interface IBookRepository
    {
        public List<Book> ListAllBooks();

        public Book CreateBook(BookDto bookDto);

        public Book UpdateBook(BookDto bookDto);

        public bool DeleteBook(BookDto bookDto);
    }
}