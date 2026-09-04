using ALDIBookProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace ALDIBookProject.Contexts
{
    public class BookDBContext : DbContext
    {
        public BookDBContext() : base() {}

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}
