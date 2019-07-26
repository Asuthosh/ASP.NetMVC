using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using WebApp_Album.Services.Interfaces;
using WebApp_Album.Models;

namespace WebApp_Album.Services
{
    public class AlbumService:IAlbumInterface
    {
        private HttpClient _client;
        public AlbumService()
        {
            _client = new HttpClient();
        }
        /// <summary>
        /// Get All Albums Details as List
        /// </summary>
        /// <returns></returns>
        public List<Album> GetAllAlbumsList()
        {
            try
            {
                var resultList = new List<Album> { };
                var getDataTask = _client.GetAsync("https://jsonplaceholder.typicode.com/albums").
                    ContinueWith(async response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = await result.Content.ReadAsAsync<List<Album>>();
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