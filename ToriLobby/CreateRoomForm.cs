using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToriLobby
{
    public partial class CreateRoomForm : Form
    {
        public CreateRoomForm()
        {
            InitializeComponent();
        }

        private void btnJoinRoom_Click(object sender, EventArgs e)
        {

            BotForm botform = new BotForm();

            botform.Show();
            botform.Start(txtUsername.Text, txtPassword.Text, txtRoomName.Text);
        }
    }
}
