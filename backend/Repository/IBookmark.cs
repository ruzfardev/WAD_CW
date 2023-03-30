using System.Collections.Generic;
using WADAPI.Models;

namespace WADAPI.Repository
{
    public interface IBookmark
    {
        IEnumerable<Bookmarks> GetBookmarksByUserId(int userId);
        void DeleteBookmark(int userId);
        void AddBookmark(Bookmarks bookmark);
    }
}
