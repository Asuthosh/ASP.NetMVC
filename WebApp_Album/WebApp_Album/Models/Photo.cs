using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_Album.Models
{
    /// <summary>
    /// Photo Class Corresponding to the API https://jsonplaceholder.typicode.com/Photos
    /// </summary>
    public class Photo
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
    }
}