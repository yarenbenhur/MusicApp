using Newtonsoft.Json;
using Spotify.Business.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business
{
    public class AlbumContext : BaseContext, IAlbumContext
    {
        public AlbumContext() : base("album.txt")
        {

        }

        public GetAlbumListResult GetAlbumList(string username)
        {
            List<Album> albums = FileOperations.ReadAllData<Album>(FilePath);
            albums = albums.Where(s => s.Username == username).ToList();
            if (albums.Count == 0)
            {
                return new GetAlbumListResult(1, "Albüm bulunamadı.", albums);
            }

            return new GetAlbumListResult(0, "Albüm listesi başarıyla alındı.",albums);
        }

        public WriteAlbumResult WriteAlbum(Album album)
        {
            List<Album> albumlist = FileOperations.ReadAllData<Album>(FilePath);
            Album checkAlbumName = albumlist.FirstOrDefault(i => i.AlbumName == album.AlbumName);
            if (checkAlbumName == null)
            {
                string createdAlbumJson = JsonConvert.SerializeObject(album);
                FileOperations.WriteDataToFile(FilePath, createdAlbumJson);
                return new WriteAlbumResult(0, "Albüm başarıyla eklendi.", album);

               
            }
            else
            {
                return new WriteAlbumResult(1, "Bu adda albüm bulunmakta.", null);
            }
        }

        public int GetAlbumId(string username)
        {
            List<Album> getAlbumList = FileOperations.ReadAllData<Album>(FilePath);
            return getAlbumList.Count();
        }


    }
}
