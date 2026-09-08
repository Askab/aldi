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

        public async Task<User?> UpdateUser(UserDto userDto)
        {
            User? user = await _set.FindAsync(userDto.Id);

            if (user == null)
                return null;

            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.RegisteredDate = userDto.RegisteredDate;

            return user;
        }

        public async Task<bool> DeleteUser(UserDto userDto)
        {
            User? user = await _set.FindAsync(userDto.Id);

            if (user == null)
                return false;

            _set.Remove(user);

            return true;
        }
    }
}
