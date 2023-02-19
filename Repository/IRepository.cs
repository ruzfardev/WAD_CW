using System.Collections.Generic;
using System.Linq;
using WAD_CW.Models;

namespace WAD_CW.Repository
{
    public interface IRepository
    {
        IEnumerable<Recipes> GetAll();
        Recipes GetById(int id);
        void Add(Recipes recipe);
        Recipes Update(int id, Recipes recipe);
        void Delete(int id);

    }
}
