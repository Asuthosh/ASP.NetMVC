using System;
using System.Collections.Generic;
using System.Linq;
using WebApp_Album.Models;
using WebApp_Album.ViewModels;
using WebApp_Album.Services;
using WebApp_Album.Services.Interfaces;

namespace WebApp_Album.Repository
{
    public class AlbumRepository
    {
        /// <summary>
        /// Private Variables 
        /// </summary>
        private IAlbumInterface _albumInterface;
        private IPhotoInterface _photoInterface;
        private IUserInterface _userInterface;
        private IEnumerable<AlbumDetails> _albumDetailsList;

        /// <summary>
        /// AlbumRepository Constructor
        /// </summary>
        public AlbumRepository()
        {
            _albumInterface = new AlbumService();
            _photoInterface = new PhotoService();
            _userInterface = new UserService();
            _albumDetailsList = new List<AlbumDetails>();
        }
        /// <summary>
        /// Joining the Album, User & Photo contents using Linq to get the required Details
        /// </summary>
        /// <param name="albums"></param>
        /// <param name="users"></param>
        /// <param name="photos"></param>
        /// <returns></returns>
        public IEnumerable<AlbumDetails> getAlbumDetails()
        {
            if (_albumDetailsList.Count() == 0)
            {
                List<Album> albums = _albumInterface.GetAllAlbumsList();
                List<User> users = _userInterface.GetAllUsersList();
                List<Photo> photos = _photoInterface.GetAllPhotosList();

                _albumDetailsList = from album in albums
                                   from user in users
                                   where album.userId == user.id
                                   from photo in photos
                                   where photo.id == (((album.id - 1) * 50) + 1)
                                   select new AlbumDetails
                                   {
                                       albumId = album.id,
                                       id = album.id,
                                       albumtitle = album.title,
                                       url = photo.url,
                                       thumbnailUrl = photo.thumbnailUrl,
                                       userid = user.id,
                                       username = user.name,
                                       email = user.email,
                                       phone = user.phone,
                                       address = user.address
                                   };
            }

            return _albumDetailsList;
        }
    }
}