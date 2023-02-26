﻿using System.Collections.Generic;
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
            var recipe = ctx.Recipes.Find(id);
            ctx.Recipes.Remove(recipe);
            Save();
        }

        public IEnumerable<Recipes> GetAll()
        {
            return ctx.Recipes
                .Include(r => r.Category)
                .Include(r => r.User).ToList();
        }

        public Recipes GetById(int id)
        {
            var recipe = ctx.Recipes.Find(id);
            return recipe;
        }

        public void Update(Recipes entity)
        {
            ctx.Entry(entity).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Save()
        {
            ctx.SaveChanges();
        }
    }
}
