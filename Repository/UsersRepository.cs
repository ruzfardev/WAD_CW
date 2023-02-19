using System.Collections.Generic;
using System.Linq;
using WAD_CW.DAL;
using WAD_CW.Models;

namespace WAD_CW.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext ctx;

        public UsersRepository(AppDbContext context)
        {
            ctx = context;
        }
        public void Add(Users user)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Users> GetAll()
        {
            var users = ctx.Users.ToList();
            return users;

        }

        public Users GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Users Update(int id, Users user)
        {
            throw new System.NotImplementedException();
        }
    }
}
