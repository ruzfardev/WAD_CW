﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WADAPI.DAL;
using WADAPI.Models;

namespace WADAPI.Repository
{
    public class BookmarksRepository : IBookmark
    {
        private readonly AppDbContext ctx;

        public BookmarksRepository(AppDbContext context)
        {
            ctx = context;
        }

        public void AddBookmark(Bookmarks bookmark)
        {
            ctx.Bookmarks.Add(bookmark);
            ctx.SaveChanges();
        }

        public void DeleteBookmark(int id)
        {
            var bookmark = ctx.Bookmarks.FirstOrDefault(x => x.Id == id);
            if (bookmark != null)
            {
                ctx.Bookmarks.Remove(bookmark);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<Bookmarks> GetBookmarksByUserId(int userId)
        {
           return ctx.Bookmarks.Where(x => x.UserId == userId);
        }
    }
}
