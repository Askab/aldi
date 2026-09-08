using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;
using ALDIBookProject.Repositories.Interfaces;
using ALDIBookProject.Services.Interfaces;

namespace ALDIBookProject.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<User>> ListAllUsers()
        {
            return _unitOfWork.UserRepository.ListAllUsers();
        }

        public Task<User?> GetById(Guid id)
        {
            return _unitOfWork.UserRepository.GetById(id);
        }

        public async Task<User> CreateUser(UserDto userDto)
        {
            User user = _unitOfWork.UserRepository.CreateUser(userDto);
            await _unitOfWork.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(UserDto userDto)
        {
            User user = _unitOfWork.UserRepository.UpdateUser(userDto);
            await _unitOfWork.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser(UserDto userDto)
        {
            bool isDeleted = _unitOfWork.UserRepository.DeleteUser(userDto);
            await _unitOfWork.SaveChangesAsync();
            return isDeleted;
        }
    }
}
