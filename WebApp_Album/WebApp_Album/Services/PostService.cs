using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using WebApp_Album.Services.Interfaces;
using WebApp_Album.Models;

namespace WebApp_Album.Services
{
    public class PostService:IPostInterface
    {
        private HttpClient _client;
        public PostService()
        {
            _client = new HttpClient();
        }
        /// <summary>
        /// Get all the posts corresponding to a UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Post> GetPostsByUserID(int userId)
        {
            try
            {
                var resultList = new List<Post> { };
                var getDataTask = _client.GetAsync(new Uri("https://jsonplaceholder.typicode.com/posts?userId=" + userId)).
                    ContinueWith(async response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = await result.Content.ReadAsAsync<List<Post>>();
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