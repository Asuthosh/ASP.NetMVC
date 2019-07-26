using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_Album.Models
{
    /// <summary>
    /// Album Class Corresponding to the API https://jsonplaceholder.typicode.com/Albums
    /// </summary>
    public class Album
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }

    }
}