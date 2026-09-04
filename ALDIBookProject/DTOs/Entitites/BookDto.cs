namespace ALDIBookProject.DTOs.Entitites
{
    public class BookDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public short PublishedYear { get; set; }

        public bool IsAvailable { get; set; }
    }
}
