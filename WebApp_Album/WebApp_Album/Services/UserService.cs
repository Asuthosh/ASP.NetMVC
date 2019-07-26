using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using WebApp_Album.Services.Interfaces;
using WebApp_Album.Models;

namespace WebApp_Album.Services
{
    public class UserService:IUserInterface
    {
        private HttpClient _client;
        public UserService()
        {
            _client = new HttpClient();
        }
        /// <summary>
        /// Get All Users Details as List
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsersList()
        {
            try
            {
                var resultList = new List<User> { };
                var getDataTask = _client.GetAsync("https://jsonplaceholder.typicode.com/users").
                    ContinueWith(async response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = await result.Content.ReadAsAsync<List<User>>();
                            resultList = readResult;
                        }
                    });

                getDataTask.Wait();
                return resultList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the Uder Details by ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<User> GetUserDetailsById(int userId)
        {
            try
            {
                var resultList = new List<User> { };
                var getDataTask = _client.GetAsync(new Uri("https://jsonplaceholder.typicode.com/users?id=" + userId)).
                    ContinueWith(async response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = await result.Content.ReadAsAsync<List<User>>();
                            resultList = readResult;
                        }
                    });

                getDataTask.Wait();
                return resultList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}