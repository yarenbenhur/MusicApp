using Spotify.Business.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business
{
    public class SongContext : BaseContext, ISongContext
    {
        public SongContext(): base("song.txt")
        {

        }

        public SongListResult GetSongListByArtistId(int artistId)
        {
            List<Song> songList = FileOperations.ReadAllData<Song>(FilePath);
            songList = songList.Where(s => s.ArtistId == artistId).ToList();

            if (songList.Count == 0)
            {
                return new SongListResult(1, "Sanatçıya ait şarkı bulunamadı.", songList);
            }

            return new SongListResult(0, "Sanatçının şarkıları başarıyla alındı.", songList);
        }
        //public SongListResult GetSongListBySongId(AlbumSongListResult result)
        //{
        //    List<Song> songList = FileOperations.ReadAllData<Song>(FilePath);
        //    songList = songList.Where(s => s.SongId == result.SongList).ToList();

        //    if (songList.Count == 0)
        //    {
        //        return new SongListResult(1, "Albüme ait şarkı bulunamadı.", songList);
        //    }

        //    return new SongListResult(0, " başarıyla alındı.", songList);

        //}


    }
}
