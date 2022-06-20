using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business.Model.Result
{
    public class GetAlbumListResult :BaseResult
    {
        public List<Album> AlbumList { get; set; }
        public GetAlbumListResult(int statusCode, string message, List<Album> albums):base(statusCode, message)
        {
            AlbumList = albums;
        }
    }
}
