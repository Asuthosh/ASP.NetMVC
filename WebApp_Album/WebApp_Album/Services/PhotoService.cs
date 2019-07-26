using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using WebApp_Album.Services.Interfaces;
using WebApp_Album.Models;

namespace WebApp_Album.Services
{
    public class PhotoService : IPhotoInterface
    {
        private HttpClient _client;
        public PhotoService()
        {
            _client = new HttpClient();
        }
        /// <summary>
        /// Get All Photos Details as List
        /// </summary>
        /// <returns></returns>
        public List<Photo> GetAllPhotosList()
        {
            try
            {
                var resultList = new List<Photo> { };
                var getDataTask = _client.GetAsync("https://jsonplaceholder.typicode.com/photos").
                    ContinueWith(async response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = await result.Content.ReadAsAsync<List<Photo>>();
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
        /// Get the Album Thumbnails by Album ID
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        public List<Photo> GetPhotosByAlbumId(int AlbumID)
        {
            try
            {
                var resultList = new List<Photo> { };
                var getDataTask = _client.GetAsync(new Uri("https://jsonplaceholder.typicode.com/photos?albumId=" + AlbumID)).
                    ContinueWith(async response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = await result.Content.ReadAsAsync<List<Photo>>();
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
