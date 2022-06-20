using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business
{
    public class Song
    {
        public int SongId { get; set; }
        public int ArtistId { get; set; }
        public string SongName { get; set; }
        public string SongPath { get; set; }
    }
}
