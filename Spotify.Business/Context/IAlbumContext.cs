using Spotify.Business.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business
{
    public interface IAlbumContext
    {
        GetAlbumListResult GetAlbumList(string username);
        int GetAlbumId(string username);
        WriteAlbumResult WriteAlbum(Album album);
    }
}
