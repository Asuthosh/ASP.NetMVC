using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_Album.Models
{
    public class Post
    {
        /// <summary>
        /// Post Class Corresponding to the API https://jsonplaceholder.typicode.com/Posts
        /// </summary>
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}