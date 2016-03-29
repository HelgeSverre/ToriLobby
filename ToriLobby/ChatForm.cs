using System;
using System.Windows.Forms;
using Toribash.Bot;
using Torilobby;

namespace ToriLobby
{
    public partial class ChatForm : Form
    {
        private Bot bot;

        public ChatForm(Room room)
        {
            InitializeComponent();

            bot = new Bot("", "");
            bot.ChatRecieved += OnMessageReceived;
            bot.Join(room);
        }

        public void OnMessageReceived(Command command)
        {
            txtChat.Text = txtChat.Text + command + "\n";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            bot.Send("SAY " + txtMessage.Text);
        }
    }
}
