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
    public partial class PlayerStatsForm : Form
    {
        public PlayerStatsForm(Dictionary<string,string> PlayerStats)
        {
            InitializeComponent();

            foreach (KeyValuePair<string, string> stat in PlayerStats)
            {
                // Create a new row
                DataGridViewRow row = new DataGridViewRow();

                // Add cells to the row
                row.Cells.Add(new DataGridViewTextBoxCell { Value = stat.Key });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = stat.Value });

                // Add the row to the list
                playerStatDataGrid.Rows.Add(row);
            }
        }
    }
}
