using System.Collections.Generic;
using System.Linq;
using WAD_CW.DAL;
using WAD_CW.Models;

namespace WAD_CW.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext ctx;

        public Repository(AppDbContext context)
        {
            ctx = context;
        }
        public void Add(Recipes recipe)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Recipes> GetAll()
        {
            var recipes = ctx.Recipes.ToList();
            return recipes;
        }

        public Recipes GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Recipes Update(int id, Recipes recipe)
        {
            throw new System.NotImplementedException();
        }
    }
}
