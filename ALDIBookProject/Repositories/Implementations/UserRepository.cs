using ALDIBookProject.Contexts;
using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;
using ALDIBookProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ALDIBookProject.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        protected readonly BookDBContext _context;
        protected readonly DbSet<User> _set;

        public UserRepository(BookDBContext context)
        {
            _context = context;
            _set = _context.Users;
        }

        public async Task<List<User>> ListAllUsers()
        {
            return await _set.ToListAsync();
        }

        public async Task<User?> GetById(Guid id)
        {
            return await _set.FindAsync(id);
        }

        public User CreateUser(UserDto userDto)
        {
            User user = new() {
                Id = Guid.NewGuid(),
                Name = userDto.Name,
                Email = userDto.Email,
                RegisteredDate = userDto.RegisteredDate,
            };

            _set.Add(user);

            return user;
        }

        public User UpdateUser(UserDto userDto)
        {
            User user = new()
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email,
                RegisteredDate = userDto.RegisteredDate,
            };

            _set.Update(user);

            return user;
        }

        public bool DeleteUser(UserDto userDto)
        {
            User user = new()
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email,
                RegisteredDate = userDto.RegisteredDate,
            };

            _set.Remove(user);

            User? result = _set.Find(userDto.Id);

            return result == null;
        }
    }
}
