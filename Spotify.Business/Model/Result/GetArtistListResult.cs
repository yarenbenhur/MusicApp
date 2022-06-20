using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business.Model.Result
{
    public class GetArtistListResult: BaseResult
    {
        public List<Artist> ArtistList { get; set; }

        public GetArtistListResult(int statusCode, string message, List<Artist> artists) : base(statusCode, message)
        {
            ArtistList = artists;
        }
    }
}
