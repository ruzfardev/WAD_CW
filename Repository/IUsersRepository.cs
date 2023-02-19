using System.Collections.Generic;
using WAD_CW.Models;

namespace WAD_CW.Repository
{
    public interface IUsersRepository
    {
        IEnumerable<Users> GetAll();
        Users GetById(int id);
        void Add(Users user);
        Users Update(int id, Users user);
        void Delete(int id);
    }
}
