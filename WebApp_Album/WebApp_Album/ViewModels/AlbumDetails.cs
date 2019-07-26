using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp_Album.Models;

namespace WebApp_Album.ViewModels
{
    /// <summary>
    /// View Model Class combining the informations 
    /// Corresponding to the API https://jsonplaceholder.typicode.com/Albums
    /// Corresponding to the API https://jsonplaceholder.typicode.com/Users
    /// Corresponding to the API https://jsonplaceholder.typicode.com/Photos
    /// </summary>
    public class AlbumDetails
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string albumtitle { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
        public int userid { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Address address { get; set; }
    }
}