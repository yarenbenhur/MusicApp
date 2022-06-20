using Newtonsoft.Json;
using Spotify.Business.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Spotify.Business
{
    public class AlbumSongContext : BaseContext, IAlbumSongContext

    {
        public AlbumSongContext() : base("albumSong.txt")
        {

        }

        public AlbumSongListResult GetsongListByAlbumId(int albumId)
        {

            List<AlbumSong> albumSongList = FileOperations.ReadAllData<AlbumSong>(FilePath);
            albumSongList = albumSongList.Where(s => s.AlbumId == albumId).ToList();
            if (albumSongList.Count == 0)
            {
                return new AlbumSongListResult(1, "Albüme ait şarkı bulunamadı.", albumSongList);
            }

            return new AlbumSongListResult(0, "Albüm şarkıları başarıyla alındı.", albumSongList);

        }
        public WriteAlbumSongResult WriteAlbumSong(AlbumSong albumsong)
        {


            string createdAlbumJson = JsonConvert.SerializeObject(albumsong);
            FileOperations.WriteDataToFile(FilePath, createdAlbumJson);
            return new WriteAlbumSongResult(0, "Albüme başarıyla eklendi.", albumsong);


        }
    }
}