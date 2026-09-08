using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;

namespace ALDIBookProject.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<User>> ListAllUsers();

        public Task<User?> GetById(int id);

        public User CreateUser(UserDto userDto);

        public User UpdateUser(UserDto userDto);

        public bool DeleteUser(UserDto userDto);
    }
}
