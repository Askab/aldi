using ALDIBookProject.Contexts;
using ALDIBookProject.Repositories.Interfaces;

namespace ALDIBookProject.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookDBContext _context;

        public IBookRepository BookRepository { get; }

        public ILoanRepository LoanRepository { get; }

        public IUserRepository UserRepository { get; }

        public UnitOfWork(
            BookDBContext dBContext,
            IBookRepository bookRepository,
            ILoanRepository loanRepository,
            IUserRepository userRepository
        ) {
            this._context = dBContext;

            this.BookRepository = bookRepository;
            this.LoanRepository = loanRepository;
            this.UserRepository = userRepository;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
