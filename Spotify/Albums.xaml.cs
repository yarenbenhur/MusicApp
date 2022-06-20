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



namespace Spotify
{
    /// <summary>
    /// Interaction logic for Albums.xaml
    /// </summary>
    public partial class Albums : BasePage
    {
        string str = Application.GetCookie(new Uri(FileOperations.BasePath));

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
        public Albums()
        {
            InitializeComponent();

            string str = Application.GetCookie(new Uri(FileOperations.BasePath));

            GetAlbumListResult result = AlbumContext.GetAlbumList(str);
            if (result.StatusCode == 0)
            {
                lbAlbum.ItemsSource = result.AlbumList;

            }
            else
            {
                MessageBox.Show(result.ResultMessage);
            }
        }
        private void lbAlbum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Album album = lbAlbum.SelectedItem as Album;
            AlbumSongListResult result = AlbumSongContext.GetsongListByAlbumId(album.AlbumId);
            if (result.StatusCode == 0)
            {
                lbAlbumSong.ItemsSource = result.AlbumSongList;

                //SongListResult songresult = SongContext.GetSongListBySongId(result);
            }
            else
            {
                MessageBox.Show(result.ResultMessage);
            }
        }
        private void btPlay_Click(object sender, RoutedEventArgs e)
        {
            AlbumSong song = ((Button)sender).DataContext as AlbumSong;
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

                // To refresh album list at the page after adding new album.
                GetAlbumListResult listresult = AlbumContext.GetAlbumList(str);
                lbAlbum.ItemsSource = listresult.AlbumList;
            }
            else
            {
                MessageBox.Show("Bu alan boş bırakılamaz.");
            }

        }
        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Popup2.IsOpen = false;

        }
    }
}