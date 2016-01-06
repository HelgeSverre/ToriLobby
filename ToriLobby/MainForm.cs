using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;

namespace ToriLobby
{
    public partial class MainForm : Form
    {

        
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
                DataGridViewRow row = new DataGridViewRow();

                row.Cells.Add(new DataGridViewTextBoxCell { Value = room.Name });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = room.Description });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = room.GameRules.Mod });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = room.IPAddress });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = room.Port.ToString() });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = room.Players.Count.ToString() });
                gameRoomList.Rows.Add(row);

            }


            int totalPlayers = lobby.getTotalPlayers();

            toolStripTotalPlayers.Text = "Players: " + totalPlayers.ToString();
            toolStripTotalLobbies.Text = "Lobbies: " + tmpRooms.Count.ToString();
        }

        private void gameRoomList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ColumnIndex RowIndex
            if (e.RowIndex > 0)
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
