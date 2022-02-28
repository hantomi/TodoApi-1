using Microsoft.EntityFrameworkCore;
using TodoApi.IRepository;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class UserRepository : IUserRepository
    {
        TnGContext _context;
        public UserRepository (TnGContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteUser(int id)
        {
            var d = await _context.Users.FindAsync(id);
            _context.Users.Remove(d);
            return true;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var us = await _context.Users.ToListAsync();
            return us;
        }

        public async Task<int> InsertUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<bool> UpdateUser(User user)
        {
            _context.Users.Update(user);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
