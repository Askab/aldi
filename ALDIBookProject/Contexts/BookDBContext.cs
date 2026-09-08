using ALDIBookProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace ALDIBookProject.Contexts
{
    public class BookDBContext : DbContext, IBookDBContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options) {}

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return this.SaveChangesAsync();
        }
    }
}
