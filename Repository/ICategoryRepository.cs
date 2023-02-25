using System.Collections.Generic;
using WADAPI.Models;

namespace WADAPI.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Categories> GetAllCategories();
        Categories GetById(int id);
        void Add(Categories category);
        void Update(Categories category);
        void Delete(int id);
    }
}
