using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;

namespace ALDIBookProject.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public List<User> ListAllUsers();

        public Book CreateUser(UserDto userDto);

        public Book UpdateUser(UserDto userDto);

        public bool DeleteUser(UserDto userDto);
    }
}
