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
    public partial class Splash : Form
    {
        clsSpotifyToken spotifyToken = new clsSpotifyToken();
        public Splash()
        {
            InitializeComponent();
            circularProgressBar.Value = 0;
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            spotifyToken.access_token = Authenticate();
        }

        private string Authenticate()
        {
            clsSpotifyToken spotifyToken = new clsSpotifyToken();
            string url = "https://accounts.spotify.com/api/token";
            var clientid = Settings.Default.ClientID;
            var clientsecret = Settings.Default.ClientSecret;

            //request to get the access token
            var encode_clientid_clientsecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", clientid, clientsecret)));

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization: Basic " + encode_clientid_clientsecret);

            var request = ("grant_type=client_credentials");
            byte[] req_bytes = Encoding.ASCII.GetBytes(request);
            webRequest.ContentLength = req_bytes.Length;

            Stream stream = webRequest.GetRequestStream();
            stream.Write(req_bytes, 0, req_bytes.Length);
            stream.Close();

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
            if (json != null)
            {
                spotifyToken = JsonConvert.DeserializeObject<clsSpotifyToken>(json);
            }

            return spotifyToken.access_token;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            circularProgressBar.Value += 1;
            circularProgressBar.Text = circularProgressBar.Value.ToString() + "%";
            if (circularProgressBar.Value == 100)
            {
                timer1.Stop();
                if (!string.IsNullOrEmpty(spotifyToken.access_token))
                {
                    Settings.Default.AuthToken = spotifyToken.access_token;
                    this.lblLoading.ForeColor = Color.Green;
                    this.lblLoading.Text = "Connected";
                    FrmMain Main = new FrmMain();
                    this.Hide();
                    Main.ShowDialog();
                    this.Close();
                }
                else
                {
                    this.lblLoading.ForeColor = Color.Red;
                    this.lblLoading.Text = "Failed to Connect..";
                }
            }
        }
    }
}
