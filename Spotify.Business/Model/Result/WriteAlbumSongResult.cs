using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business.Model.Result
{
    public class WriteAlbumSongResult : BaseResult
    {
        public AlbumSong AlbumSong { get; set; }
        public WriteAlbumSongResult(int statusCode, string message, AlbumSong albumsong) : base(statusCode, message)
        {
            AlbumSong = albumsong;
        }
    }
}
