using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business.Model.Result
{
    public class WriteAlbumResult : BaseResult
    {
        public Album Album { get; set; }
        public WriteAlbumResult(int statusCode, string message, Album album) : base(statusCode, message)
        {
            Album = album;
        }
    }
}
