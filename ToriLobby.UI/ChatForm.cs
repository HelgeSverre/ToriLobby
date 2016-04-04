using System;
using System.Windows.Forms;
using Torilobby.Client;
using ToriLobby.Client;

namespace ToriLobby
{
    public partial class ChatForm : Form
    {
        private Bot bot;

        public ChatForm(Room room)
        {
            InitializeComponent();


            Credentials creds = new Credentials("", "");

            bot = new Bot(creds);
            // bot.ChatRecieved += OnMessageReceived;
            bot.Join(room);
        }

        public void OnMessageReceived(Command command)
        {
            txtChat.Text = txtChat.Text + command + "\n";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // bot.Send("SAY " + txtMessage.Text);
        }
    }
}
