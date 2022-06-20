using Spotify.Business;
using Spotify.Business.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Newtonsoft;
using Newtonsoft.Json;

namespace Spotify
{
    /// <summary>
    /// Interaction logic for Music.xaml
    /// </summary>
    public partial class Music : BasePage

    {
        string str = Application.GetCookie(new Uri(FileOperations.BasePath));
        Song song = new Song();
        private MediaPlayer FieldMediaPlayer;
        public MediaPlayer MediaPlayer
        {
            get
            {
                if (FieldMediaPlayer == default(MediaPlayer))
                {
                    FieldMediaPlayer = new MediaPlayer();
                }
                return FieldMediaPlayer;
            }
        }

        public Music()
        {
            InitializeComponent();

            MessageBox.Show(str);

            GetArtistListResult result = ArtistContext.GetArtistList();
            if (result.StatusCode == 0)
            {
                lbArtist.ItemsSource = result.ArtistList;
            }
            else
            {
                MessageBox.Show(result.ResultMessage);
            }


        }

        private void lbArtist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Artist artist = lbArtist.SelectedItem as Artist;
            SongListResult result = SongContext.GetSongListByArtistId(artist.Id);
            if (result.StatusCode == 0)
            {
                lbSong.ItemsSource = result.SongList;
            }
            else
            {
                MessageBox.Show(result.ResultMessage);
            }
        }

        private void btPlay_Click(object sender, RoutedEventArgs e)
        {
            Song song = ((Button)sender).DataContext as Song;
            if (MediaPlayer.Source != new Uri(song.SongPath))
            {
                MediaPlayer.Open(new Uri(song.SongPath));
            }
            MediaPlayer.Play();
        }

        private void lbStop_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Pause();
        }
        private void btAlbum_Click(object sender, RoutedEventArgs e)
        {

            GetAlbumListResult result = AlbumContext.GetAlbumList(str);
            if (result.StatusCode == 0)
            {
                NavigationService navigationService = NavigationService.GetNavigationService(this);
                navigationService.Navigate(new Uri("Albums.xaml", UriKind.RelativeOrAbsolute));

            }
            else
            {
                MessageBox.Show(result.ResultMessage);
            }


        }
        //Add new song to the album.
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {

            song = ((Button)sender).DataContext as Song;
         
            GetAlbumListResult result = AlbumContext.GetAlbumList(str);
            if (result.StatusCode == 0)
            {
                lbChooseAlbum.ItemsSource = result.AlbumList;
                Popup1.IsOpen = true;

            }
            else
            {
                MessageBox.Show(result.ResultMessage);
            }

        }

        private void lbChooseAlbum_Selection(object sender, SelectionChangedEventArgs e)
        {
            //Unselectall() sets the index of the selected item in Listbox to -1
            //which makes a change in the selection and inserts into this method again.
            //To prevent enter the loop, set the condition as index not equal to -1.

            if (lbChooseAlbum.SelectedIndex != -1)
            {
                Album album = lbChooseAlbum.SelectedItem as Album;

                AlbumSong albumSong = new AlbumSong()
                {
                    AlbumId = album.AlbumId,
                    SongId = song.SongId,
                    Username = str,
                    SongName = song.SongName,
                    SongPath = song.SongPath

                };

                WriteAlbumSongResult result = AlbumSongContext.WriteAlbumSong(albumSong);

                MessageBox.Show(result.ResultMessage);

                Popup1.IsOpen = false;
                lbChooseAlbum.UnselectAll();
            }
        }

        private void btAlbumOlustur_Click(object sender, RoutedEventArgs e)
        {
            Popup2.IsOpen = true;

        }
        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbAlbumName.Text.Trim() != "")
            {
                Album album = new Album()
                {
                    AlbumName = tbAlbumName.Text.Trim(),
                    AlbumId = AlbumContext.GetAlbumId(str) + 1,
                    Username = str.Trim()
                };

                WriteAlbumResult result = AlbumContext.WriteAlbum(album);
                MessageBox.Show(result.ResultMessage);
                Popup2.IsOpen = false;
            }
            else
            {
                MessageBox.Show("Bu alan boş bırakılamaz.");
            }
        }
        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Popup2.IsOpen = false;
            Popup1.IsOpen = false;
        }

    }
}
