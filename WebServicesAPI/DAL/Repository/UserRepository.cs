using Microsoft.EntityFrameworkCore;
using WebServicesAPI.DAL.Data;
using WebServicesAPI.DAL.Models;

namespace WebServicesAPI.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddUser(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _appDbContext.Users.Find(id);
            if (user != null)
            {
                _appDbContext.Users.Remove(user);
                _appDbContext.SaveChanges();
            }

        }

        public IEnumerable<User> GetAllUsers()
        {
            return _appDbContext.Users
               .Include(u => u.PhoneNumbers)
               .Include(u => u.Addresses)
               .ToList();   
        }

        public User GetUserById(int id)
        {
            return _appDbContext.Users
                .Include(u => u.PhoneNumbers)
                .Include(u => u.Addresses)
                .FirstOrDefault(u => u.Id == id);
        }

        public void UpdateUser(User user)
        {
            user.UpdationTime = DateTime.UtcNow;
            _appDbContext.Users.Update(user);
            _appDbContext.SaveChanges();
        }
    }
}
