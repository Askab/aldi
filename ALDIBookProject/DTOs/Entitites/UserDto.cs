namespace ALDIBookProject.DTOs.Entitites
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime RegisteredDate { get; set; } = DateTime.Now;
    }
}
