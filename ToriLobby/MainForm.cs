using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Client;

namespace ToriLobby
{
    public partial class MainForm : Form
    {

        // TODO: Move this into a config file or grab it from somewhere on launch
        string lobbyHost = "144.76.163.135";
        int lobbyPort = 22000;

        public Lobby lobby;


        public MainForm()
        {
            InitializeComponent();

            lobby = new Lobby(lobbyHost, lobbyPort);
        }


        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lobby.Update();
            Render();
        }

        private void Render()
        {
            gameRoomList.Rows.Clear();

            List<Room> tmpRooms = lobby.GetRooms();

            foreach (Room room in tmpRooms)
            {
                // Create a new row
                DataGridViewRow row = new DataGridViewRow();

                // Add cells to the row
                row.Cells.Add(new DataGridViewTextBoxCell { Value = room.Name });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = room.Description });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = room.GameRules.Mod });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = room.IPAddress });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = room.Port });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = room.Players.Count });

                // Add the row to the list
                gameRoomList.Rows.Add(row);
            }

            int totalPlayers = lobby.GetTotalPlayers();

            // TODO: See if there is a better way to inject this counter thingy into the string without having to remember the "Players: " part
            toolStripTotalPlayers.Text = "Players: " + totalPlayers.ToString();
            toolStripTotalLobbies.Text = "Rooms: " + tmpRooms.Count.ToString();
        }

        private void gameRoomList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gameRoomList.Rows[e.RowIndex];

                // TODO: This is a poor way of getting this information, should be using a datasource or databinding instead.
                Room selectedGameRoom = lobby.GetRooms().Find(item => item.Name == (string)row.Cells[0].Value);
                FillPlayerList(selectedGameRoom);
            }
        }

        private void PlayerList_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Grab the selected player from the list
            String playerName = (string)PlayerList.Items[PlayerList.SelectedIndex];

            // If the selected playername is valid (which it probably is)
            if (!String.IsNullOrEmpty(playerName))
            {
                var playerStats = Player.getStats(playerName);

                PlayerStatsForm playerStatsForm = new PlayerStatsForm(playerStats);
                playerStatsForm.Show();
            }
        }


        private void gameRoomList_SelectionChanged(object sender, EventArgs e)
        {
            string selectedLobbyName = (string)gameRoomList.SelectedRows[0].Cells[0].Value;
            Room selectedGameRoom = lobby.GetRooms().Find(item => item.Name == selectedLobbyName);

            // When you pick a room in the list, display that room's players
            FillPlayerList(selectedGameRoom);
        }



        // Fills the player list with the players in a room
        private void FillPlayerList(Room selectedGameRoom)
        {
            PlayerList.Items.Clear();

            foreach (Player player in selectedGameRoom.Players)
            {
                PlayerList.Items.Add(player.Username);
            }
        }

        private void joinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test", "Hai");
        }

        private void joinSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string selectedLobbyName = (string)gameRoomList.SelectedRows[0].Cells[0].Value;
            Room selectedGameRoom = lobby.GetRooms().Find(item => item.Name == selectedLobbyName);

            var test = new Client.Client("torilobby", "Toribash123");

            test.Join(selectedGameRoom);


        }
    }

}
