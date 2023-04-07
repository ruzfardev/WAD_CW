using System;
using System.Collections.Generic;
using System.Transactions;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using WADAPI.Models;
using WADAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WADAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly IBookmark _bookmark;
        public BookmarkController(IBookmark bookmark)
        {
            _bookmark = bookmark;
        }
        // GET: api/Bookmark/5
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}", Name = "GetBookmark")]
        public IActionResult Get(int id)
        {
            var userBookmarks = _bookmark.GetBookmarksByUserId(id);
            return new OkObjectResult(userBookmarks);
        }
        // POST: api/Bookmark
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult Post([Microsoft.AspNetCore.Mvc.FromBody] Bookmarks bookmark)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _bookmark.AddBookmark(bookmark);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = bookmark.Id }, bookmark);
                }
            }
            catch (Exception e)
            {
                return CreatedAtAction(nameof(Get), new EmptyResult(), e.Message);
            }
            
        }
        // DELETE: api/ApiWithActions/5
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookmark.DeleteBookmark(id);
            return new OkResult();
        }
    }
}
