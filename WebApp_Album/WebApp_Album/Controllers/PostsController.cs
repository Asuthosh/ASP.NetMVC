using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using WebApp_Album.Services;
using WebApp_Album.Services.Interfaces;

namespace WebApp_Album.Controllers
{
    public class PostsController : Controller
    {
        private IPostInterface _postInterface;
        public PostsController()
        {
            _postInterface = new PostService();
        }
        // GET: Posts
        /// <summary>
        /// Index methos which also handles pagination
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public ActionResult Index(int? userid, int? pageNumber)
        {
            try
            {
                var posts = _postInterface.GetPostsByUserID(userid ?? 1);
                return View(posts.ToList().ToPagedList(pageNumber ?? 1, 5));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Home", "Index"));
            }

        }
    }
}