using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace ToriLobby
{
    public partial class MainForm : Form
    {

        // TODO: Move this into a config file or grab it from somewhere on launch
        string lobbyHost = "144.76.163.135";
        int lobbyPort = 22000;

        Lobby lobby;


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

        
        // TODO: Move this into its own class
        
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

            int totalPlayers = lobby.getTotalPlayers();

            // TODO: See if there is a better way to inject this counter thingy into the string without having to remember the "Players: " part
            toolStripTotalPlayers.Text = "Players: " + totalPlayers.ToString();
            toolStripTotalLobbies.Text = "Lobbies: " + tmpRooms.Count.ToString();
        }

        private void gameRoomList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ColumnIndex RowIndex
            if (e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow row = gameRoomList.Rows[rowIndex];


                Room SelectedGameRoom = lobby.GetRooms().Find(item => item.Name == (string)row.Cells[0].Value);

                PlayerList.Items.Clear();

                foreach (string player in SelectedGameRoom.Players)
                {
                    PlayerList.Items.Add(player);
                }
            }
        }
    }

}
