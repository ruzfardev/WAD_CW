using System.Collections.Generic;
using WADAPI.Models;

namespace WADAPI.Repository
{
    public interface IUsersRepository
    {
        IEnumerable<Users> GetAllUsers();
        Users GetUserById(int id);
        void CreateUser(Users user);
        void UpdateUser(Users user);
        void DeleteUser(int id);
    }
}
