using Spotify.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Spotify
{
    public class BasePage : Page
    {
        private IUserContext FieldUserContext;
        public IUserContext UserContext
        {
            get
            {
                if (FieldUserContext == default(IUserContext))
                {
                    FieldUserContext = new UserContext();
                }

                return FieldUserContext;
            }
        }

        private IArtistContext FieldArtistContext;
        public IArtistContext ArtistContext
        {
            get
            {
                if (FieldArtistContext == default(IArtistContext))
                {
                    FieldArtistContext = new ArtistContext();
                }
                return FieldArtistContext;
            }
        }

        private ISongContext FieldSongContext;
        public ISongContext SongContext
        {
            get
            {
                if (FieldSongContext == default(ISongContext))
                {
                    FieldSongContext = new SongContext();
                }
                return FieldSongContext;
            }
        }
        private IAlbumContext FieldAlbumContext;
        public IAlbumContext AlbumContext
        {
            get
            {
                if (FieldAlbumContext== default(IAlbumContext))
                {
                    FieldAlbumContext = new AlbumContext();
                }
                return FieldAlbumContext;
            }
        }
        private IAlbumSongContext FieldAlbumSongContext;
        public IAlbumSongContext AlbumSongContext
        {
            get
            {
                if (FieldAlbumSongContext == default(IAlbumSongContext))
                {
                    FieldAlbumSongContext = new AlbumSongContext();
                }
                return FieldAlbumSongContext;

            }
        }
    }
}
