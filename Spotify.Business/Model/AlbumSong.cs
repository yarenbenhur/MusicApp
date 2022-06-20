using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business
{
    public class AlbumSong
    {
        public int  AlbumId { get; set; }
        public int SongId { get; set; }
        public string Username{ get; set; }
        public string SongName { get; set; }
        public string SongPath { get; set; }
    }
}
