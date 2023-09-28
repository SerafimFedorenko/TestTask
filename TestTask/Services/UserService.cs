using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetUser()
        {
            var user = _context.Users.OrderByDescending(user => user.Orders.Count()).FirstOrDefault();
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = _context.Users.Where(user => user.Status == Enums.UserStatus.Inactive).ToList();
            return users;
        }
    }
}
