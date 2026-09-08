using System.ComponentModel.DataAnnotations;

namespace ALDIBookProject.Entities
{
    public class Loan
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid BookId { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
