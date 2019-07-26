using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApp_Album.ViewModels;
using WebApp_Album.Services;
using WebApp_Album.Services.Interfaces;
using WebApp_Album.Repository;

namespace WebApp_Album.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Private Variables 
        /// </summary>
        private AlbumRepository _albumRepositoy;
        private IEnumerable<AlbumDetails> _albumDetailsList;

        /// <summary>
        /// HomeController Constructor
        /// </summary>
        public HomeController()
        {
            _albumRepositoy = new AlbumRepository();
            _albumDetailsList = new List<AlbumDetails>();
        }

        /// <summary>
        /// Index method which handles both search and pagination
        /// </summary>
        /// <param name="option"></param>
        /// <param name="search"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public ActionResult Index(string option, string search, int? pageNumber)
        {
            try
            {
                _albumDetailsList = _albumRepositoy.getAlbumDetails();

                //Linq Search/Filter Logic
                if ((search != null) && (option != null))
                {
                    //Search by Album Title
                    if (option == "AlbumTitle")
                    {
                        return View(_albumDetailsList.Where(x => x.albumtitle.ToLower().Contains(search.ToLower())).ToList().ToPagedList(pageNumber ?? 1, 6));
                    }
                    //Search by User Name
                    else
                    {
                        return View(_albumDetailsList.Where(x => x.username.ToLower().Contains(search.ToLower())).ToList().ToPagedList(pageNumber ?? 1, 6));
                    }
                }  
                //Search all without any filters 
                else
                {
                    return View(_albumDetailsList.ToList().ToPagedList(pageNumber ?? 1, 6));
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Home", "Index"));
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}