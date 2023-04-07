using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
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

        public IEnumerable<Categories> GetByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        public void Update(Categories entity)
        {
            throw new NotImplementedException();
        }
    }
}
