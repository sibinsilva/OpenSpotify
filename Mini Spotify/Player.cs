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
        SongTracks Songs = new SongTracks();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtQuery.Text))
            {
                SearchSong(this.txtQuery.Text);
            }
            else
            {
                MessageBox.Show("Please enter a song/artist name.");
            }
        }

        private void SearchSong(string text)
        {
            string url = "https://api.spotify.com/v1/search?query=" + text + "&type=track&&limit=20&offset=0";

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
                    this.btnStop.Visible = true;
                    foreach (var item in Songs.tracks.items)
                    {
                        this.lvPlayList.Items.Add(item.name);
                    }
                }
                else
                {
                    MessageBox.Show("No Results found...");
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string URL = null;
            if (this.lvPlayList.SelectedItems.Count > 0)
            {
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
    }
}
