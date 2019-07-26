using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using WebApp_Album.Services;
using WebApp_Album.Services.Interfaces;

namespace WebApp_Album.Controllers
{
    /// <summary>
    /// Controller class to deal with Photos
    /// </summary>
    public class PhotosController : Controller
    {
        private IPhotoInterface _photoInterface;
        public PhotosController()
        {
            _photoInterface = new PhotoService();
        }
        /// <summary>
        /// Combined Navigation with input parameters albumId and pageNumber
        /// </summary>
        /// <param name="albumId"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public ActionResult Index(int? albumId, int? pageNumber)
        {
            try
            {
                var albumphotos = _photoInterface.GetPhotosByAlbumId(albumId ?? 1);
                return View(albumphotos.ToList().ToPagedList(pageNumber ?? 1, 10));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Home", "Index"));
            }
        }
    }
}