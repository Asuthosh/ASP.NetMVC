﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp_Album.Models;

namespace WebApp_Album.Services.Interfaces
{
    public interface IPostInterface
    {
        List<Post> GetPostsByUserID(int userId);
    }
}