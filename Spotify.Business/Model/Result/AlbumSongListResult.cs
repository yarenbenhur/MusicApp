using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business.Model.Result
{
    public class AlbumSongListResult : BaseResult
    {
        public List<AlbumSong> AlbumSongList { get; set; }

        public AlbumSongListResult(int statusCode, string resultMessage, List<AlbumSong> albumsongs) : base(statusCode, resultMessage)
        {
            AlbumSongList = albumsongs;
        }

    }
    
}
