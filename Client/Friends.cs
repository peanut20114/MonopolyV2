using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Numerics;

namespace Client
{
    public partial class Friends : Form
    {   public class Player
        {
            public string Username { get; set; }
            public string LastLoggedIn { get; set; }
        }
        private Dictionary<string, Player> players;


        public Friends()
        {
            InitializeComponent();
        }

        private void LoadUserData()
        {
            string jsonFilePath = "D:\\UIT\\LapTrinhMang\\monopoly\\Fake_Database\\USER.json";
            if (File.Exists(jsonFilePath)) 
            {
                string jsonText = File.ReadAllText(jsonFilePath);
                players = JsonConvert.DeserializeObject<Dictionary<string, Player>>(jsonText);
            }
            else
            {
                MessageBox.Show("Player not found.");
                players = new Dictionary<string, Player>();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchUsername = richTextBox1.Text;
            List<Player> searchResults = players.Values.Where(u  => u.Username == searchUsername).ToList();

            listView1.Items.Clear();

            foreach (var player in searchResults) 
            {

            }
        }

       
    }
}
