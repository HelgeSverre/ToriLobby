using System.Windows.Forms;

namespace ToriLobby
{
    public partial class BotForm : Form
    {


        public BotForm()
        {
            InitializeComponent();

        }


        public void Start(string user, string password, string room)
        {

            // TODO: Get this info from somewhere else
            string lobbyHost = "144.76.163.135";
            int lobbyPort = 22001;


            Bot test = new Bot(user, password, lobbyHost, lobbyPort );
            test.Join(room);
        }
    }
}
