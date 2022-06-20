using Spotify.Business.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business
{
    public class ArtistContext : BaseContext, IArtistContext
    {
        public ArtistContext() : base("artist.txt")
        {

        }
        public GetArtistListResult GetArtistList()
        {
            List<Artist> artists = FileOperations.ReadAllData<Artist>(FilePath);
            if (artists.Count == 0)
            {
                return new GetArtistListResult(1, "Sanatçı bulunamadı.", artists);
            }

            return new GetArtistListResult(0, "Sanatçı listesi başarıyla alındı.", artists);
        }
    }
}
