using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WADAPI.DAL;
using WADAPI.Models;

namespace WADAPI.Repository
{
    public class CategoryRepository : IRepository<Categories>
    {
        private readonly AppDbContext ctx;

        public CategoryRepository(AppDbContext context)
        {
            ctx = context;
        }
        public void Add(Categories category)
        {
            ctx.Categories.Add(category);   
            Save();
        }

        public void Delete(int id)
        {
            ctx.Categories.Remove(this.GetById(id));
            Save();
        }

        public IEnumerable<Categories> GetAll()
        {
            return ctx.Categories.ToList();
        }

        public Categories GetById(int id)
        {
            return ctx.Categories.Find(id);
        }

        public void Update(Categories category)
        {
            ctx.Entry(category).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Save()
        {
            ctx.SaveChanges();
        }
    }
}
