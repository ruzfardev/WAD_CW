using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WADAPI.DAL;
using WADAPI.Models;

namespace WADAPI.Repository
{
    public class UsersRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UsersRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Users user)
        {
            _dbContext.Users.Add(user);
            Save();
        }

        public void Delete(int id)
        {
            _dbContext.Users.Remove(this.GetById(id));
            Save();
        }

        public IEnumerable<Users> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public Users GetById(int id)
        {
            var user = _dbContext.Users.Find(id);
            return user;

        }

        public void Update(Users user)
        {
            _dbContext.Entry(user).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
        // Login user.
        // Find user with provided email and password if there is user
        // return it
        public Users ValidateUser(string email, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return user;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
