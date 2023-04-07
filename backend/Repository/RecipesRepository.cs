using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Transactions;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
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

        public void Update(Recipes entity)
        {
            ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        public IEnumerable<Recipes> GetByUserId(int userId)
        {
            return ctx.Recipes.Where(x=>x.UserId == userId).ToList();
        }
    }
}
