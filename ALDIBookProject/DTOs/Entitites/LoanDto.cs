using ALDIBookProject.Entities;

namespace ALDIBookProject.DTOs.Entitites
{
    public class LoanDto
    {
        public Guid Id { get; set; }

        public User User { get; set; }

        public Book Book { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
