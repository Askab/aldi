using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;

namespace ALDIBookProject.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<User>> ListAllUsers();

        public Task<User?> GetById(Guid id);

        public Task<User> CreateUser(UserDto userDto);

        public Task<User> UpdateUser(UserDto userDto);

        public Task<bool> DeleteUser(UserDto userDto);
    }
}
