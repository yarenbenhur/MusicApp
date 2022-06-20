using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business.Model.Result
{
    public class SongListResult : BaseResult
    {
        public List<Song> SongList { get; set; }

        public SongListResult(int statusCode, string resultMessage, List<Song> songs) : base(statusCode, resultMessage)
        {
            SongList = songs;
        }
    }
}
