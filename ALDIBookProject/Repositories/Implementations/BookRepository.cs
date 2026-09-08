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
                Id = Guid.NewGuid(),
                Title = bookDto.Title,
                Author = bookDto.Author,
                ISBN = bookDto.ISBN,
                PublishedYear = bookDto.PublishedYear,
                IsAvailable = bookDto.IsAvailable
            };

            _set.Add(book);

            return book;
        }

        public async Task<Book?> UpdateBook(Guid id, BookDto bookDto)
        {
            Book? book = await _set.FindAsync(id);

            if (book == null)
                return null;

            book.Title = bookDto.Title;
            book.Author = bookDto.Author;
            book.ISBN = bookDto.ISBN;
            book.PublishedYear = bookDto.PublishedYear;
            book.IsAvailable = bookDto.IsAvailable;

            return book;
        }

        public async Task<bool> DeleteBook(BookDto bookDto)
        {
            Book? book = await _set.FindAsync(bookDto.Id);

            if (book == null)
                return false;

            _set.Remove(book);

            return true;
        }
    }
}