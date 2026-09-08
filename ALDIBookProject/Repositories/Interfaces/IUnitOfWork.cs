namespace ALDIBookProject.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; }
        ILoanRepository LoanRepository { get; }
        IUserRepository UserRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
