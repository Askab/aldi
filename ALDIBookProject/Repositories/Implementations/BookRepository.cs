using ALDIBookProject.Contexts;
using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;
using ALDIBookProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ALDIBookProject.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        protected readonly BookDBContext _context;
        protected readonly DbSet<Book> _set;

        public BookRepository(BookDBContext context) 
        {
            _context = context;
            _set = _context.Books;
        }

        public async Task<List<Book>> ListAllBooks()
        {
            return await _set.ToListAsync();
        }

        public async Task<Book?> GetById(Guid id)
        {
            return await _set.FindAsync(id);
        }

        public Book CreateBook(BookDto bookDto)
        {
            Book book = new Book() {
                Title = bookDto.Title,
                Author = bookDto.Author,
                ISBN = bookDto.ISBN,
                PublishedYear = bookDto.PublishedYear,
                IsAvailable = bookDto.IsAvailable
            };

            _set.Add(book);

            return book;
        }

        public Book UpdateBook(BookDto bookDto)
        {
            Book book = new Book()
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                Author = bookDto.Author,
                ISBN = bookDto.ISBN,
                PublishedYear = bookDto.PublishedYear,
                IsAvailable = bookDto.IsAvailable
            };

            _set.Update(book);

            return book;
        }

        public bool DeleteBook(BookDto bookDto)
        {
            Book book = new Book()
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                Author = bookDto.Author,
                ISBN = bookDto.ISBN,
                PublishedYear = bookDto.PublishedYear,
                IsAvailable = bookDto.IsAvailable
            };

            _set.Remove(book);

            Book? result = _set.Find(book.Id);

            return result == null;
        }
    }
}