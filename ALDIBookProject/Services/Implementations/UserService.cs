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

        public User CreateUser(UserDto userDto)
        {
            return _unitOfWork.UserRepository.CreateUser(userDto);
        }

        public User UpdateUser(UserDto userDto)
        {
            return _unitOfWork.UserRepository.UpdateUser(userDto);
        }

        public bool DeleteUser(UserDto userDto)
        {
            return _unitOfWork.UserRepository.DeleteUser(userDto);
        }
    }
}
