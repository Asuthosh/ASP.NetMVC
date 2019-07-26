using System;
using System.Web.Mvc;
using WebApp_Album.Services;
using WebApp_Album.Services.Interfaces;

namespace WebApp_Album.Controllers
{
    public class UsersController : Controller
    {
        private IUserInterface _userService;
        public UsersController()
        {
            _userService = new UserService();
        }
        /// <summary>
        /// Index Method
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult Index(int? userId)
        {
            try
            {
                var users = _userService.GetUserDetailsById(userId ?? 1);
                return View(users[0]);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Home", "Index"));
            }
        }
    }

}