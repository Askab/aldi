using System.ComponentModel.DataAnnotations;

namespace ALDIBookProject.Entities
{
    public class Loan
    {
        [Key]
        public Guid Id { get; set; }

        public User User { get; set; }

        public Book Book { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
