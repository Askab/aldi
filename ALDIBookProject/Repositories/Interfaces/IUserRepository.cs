using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;

namespace ALDIBookProject.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> ListAllUsers();

        public Task<User?> GetById(Guid id);

        public Task<User?> GetByEmail(string email);

        public User CreateUser(UserDto userDto);

        public Task<User?> UpdateUser(Guid id, UserDto userDto);

        public Task<bool> DeleteUser(UserDto userDto);
    }
}
