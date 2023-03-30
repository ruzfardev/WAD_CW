using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WADAPI.DAL;
using WADAPI.Models;

namespace WADAPI.Repository
{
    public class RecipesRepository : IRepository<Recipes>
    {
        private readonly AppDbContext ctx;

        public RecipesRepository(AppDbContext context)
        {
            ctx = context;
        }
        public void Add(Recipes entity)
        {
            ctx.Recipes.Add(entity);
            Save();
        }

        public void Delete(int id)
        {
            ctx.Recipes.Remove(this.GetById(id));
            Save();
        }

        public IEnumerable<Recipes> GetAll()
        {
            return ctx.Recipes.ToList();
        }

        public Recipes GetById(int id)
        {
            return ctx.Recipes.Find(id);
        }

        public void Update(Recipes entity, int id)
        {
            var existingEntity = ctx.Recipes.FirstOrDefault(r => r.Id == id);

            if (existingEntity != null)
            {
                ctx.Entry(entity).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                Save();
            }
        }

        public void Save()
        {
            ctx.SaveChanges();
        }
    }
}
