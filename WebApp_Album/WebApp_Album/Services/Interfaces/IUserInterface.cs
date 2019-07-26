using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp_Album.Models;

namespace WebApp_Album.Services.Interfaces
{
    public interface IUserInterface
    {
        List<User> GetAllUsersList();
        List<User> GetUserDetailsById(int userId);
    }
}