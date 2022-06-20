using Spotify.Business.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business
{
    public interface IAlbumSongContext
    {
        AlbumSongListResult GetsongListByAlbumId(int albumId);
        WriteAlbumSongResult WriteAlbumSong(AlbumSong albumSong);
    }
}
