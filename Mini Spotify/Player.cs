using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Spotify
{
    public partial class FrmMain : Form
    {
        public static string SongURL = null;
        public static bool IsPlaying = false;
        SongTracks Songs = new SongTracks();
        public static int Offset = 0;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtQuery.Text))
            {
                SearchSong(this.txtQuery.Text,false);
            }
            else
            {
                MessageBox.Show("Please enter a song/artist name.");
            }
        }

        private void SearchSong(string text,bool IsNextPage)
        {
            if (IsNextPage)
            {
                Offset += 1;
            }
            string url = "https://api.spotify.com/v1/search?query=" + text + "&type=track&&limit=20&offset="+Offset;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.ContentType = "application/json";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization: Bearer  " + Settings.Default.AuthToken);

            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            String json = "";
            using (Stream respStr = resp.GetResponseStream())
            {
                using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                {
                    json = rdr.ReadToEnd();
                    rdr.Close();
                }
            }
            if (!string.IsNullOrEmpty(json))
            {
                Songs = JsonConvert.DeserializeObject<SongTracks>(json);
                if (Songs.tracks.items.Count > 0)
                {
                    if (lvPlayList.Items.Count > 0)
                    {
                        lvPlayList.Items.Clear();
                    }
                    this.lvPlayList.Visible = true;
                    this.btnPlay.Visible = true;
                    this.btnStop.Text = "Next";
                    this.btnStop.Visible = true;
                    ImageList images = new ImageList();
                    if (images.Images.Count > 0)
                    {
                        images.Images.Clear();
                    }
                    int i = 0;
                    foreach (var item in Songs.tracks.items)
                    {
                        images.Images.Add(LoadImage(item.album.images[2].url.ToString()));
                        this.lvPlayList.Items.Add(item.name,i);
                    }
                    this.lvPlayList.LargeImageList = images;
                }
                else
                {
                    MessageBox.Show("No Results found...");
                }
            }
        }

        private Image LoadImage(string url)
        {
            System.Net.WebRequest request =
                System.Net.WebRequest.Create(url);

            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream =
                response.GetResponseStream();

            Bitmap bmp = new Bitmap(responseStream);

            responseStream.Dispose();

            return bmp;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string URL = null;
            if (this.lvPlayList.SelectedItems.Count > 0)
            {
                if (IsPlaying)
                {
                    IsPlaying = false;
                    this.btnPlay.Text = "Play";
                }
                else
                {
                    IsPlaying = true;
                    this.btnStop.Text = "Stop";
                    this.btnPlay.Text = "Pause";
                    var Item = this.lvPlayList.SelectedItems[0];
                    foreach (var item in Songs.tracks.items)
                    {
                        if (item.name == Item.Text.ToString())
                        {
                            URL = item.external_urls.spotify;
                            System.Diagnostics.Process.Start(URL);
                            break;
                        }
                    }
                } 
            }
            else
            {
                MessageBox.Show("Please make a selection...");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!IsPlaying)  //Next Page requested
            {
                SearchSong(this.txtQuery.Text, true);
            }
            else
            {
                this.btnPlay.Text = "Play";
            }
        }
    }
}
