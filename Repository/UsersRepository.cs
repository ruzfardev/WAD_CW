using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WADAPI.DAL;
using WADAPI.Models;

namespace WADAPI.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext _dbContext;
        public UsersRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateUser(Users user)
        {
            _dbContext.Users.Add(user);
            Save();
        }

        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.Find(id);
            _dbContext.Users.Remove(user);
            Save();
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public Users GetUserById(int id)
        {
            var user = _dbContext.Users.Find(id);
            return user;

        }

        public void UpdateUser(Users user)
        {
            _dbContext.Entry(user).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
