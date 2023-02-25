using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WADAPI.DAL;
using WADAPI.Models;

namespace WADAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
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
            var category = ctx.Categories.Find(id);
            ctx.Categories.Remove(category);
            Save();
        }

        public IEnumerable<Categories> GetAllCategories()
        {
            return ctx.Categories.ToList();
        }

        public Categories GetById(int id)
        {
            var cate = ctx.Categories.Find(id);
            return cate;
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
