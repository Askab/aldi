using System.ComponentModel.DataAnnotations;

namespace ALDIBookProject.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime RegisteredDate { get; set; } = DateTime.Now;
    }
}
