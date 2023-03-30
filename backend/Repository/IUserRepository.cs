using System.Collections.Generic;
using WADAPI.Models;

namespace WADAPI.Repository
{
    public interface IUserRepository
    {
        IEnumerable<Users> GetAll();
        Users GetById(int id);
        void Add(Users entity);
        void Update(Users entity);
        void Delete(int id);

        Users ValidateUser(string email, string password);
    }
}
