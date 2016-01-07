namespace ToriLobby
{
    partial class PlayerStatsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playerStatDataGrid = new System.Windows.Forms.DataGridView();
            this.statName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.playerStatDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // playerStatDataGrid
            // 
            this.playerStatDataGrid.AllowUserToAddRows = false;
            this.playerStatDataGrid.AllowUserToDeleteRows = false;
            this.playerStatDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.playerStatDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.playerStatDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playerStatDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statName,
            this.statValue});
            this.playerStatDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerStatDataGrid.Location = new System.Drawing.Point(0, 0);
            this.playerStatDataGrid.Name = "playerStatDataGrid";
            this.playerStatDataGrid.ReadOnly = true;
            this.playerStatDataGrid.RowHeadersVisible = false;
            this.playerStatDataGrid.RowTemplate.Height = 24;
            this.playerStatDataGrid.Size = new System.Drawing.Size(295, 398);
            this.playerStatDataGrid.TabIndex = 0;
            // 
            // statName
            // 
            this.statName.HeaderText = "Name";
            this.statName.Name = "statName";
            this.statName.ReadOnly = true;
            // 
            // statValue
            // 
            this.statValue.HeaderText = "Value";
            this.statValue.Name = "statValue";
            this.statValue.ReadOnly = true;
            // 
            // PlayerStatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(295, 398);
            this.Controls.Add(this.playerStatDataGrid);
            this.Name = "PlayerStatsForm";
            this.ShowIcon = false;
            this.Text = "Player Stats";
            ((System.ComponentModel.ISupportInitialize)(this.playerStatDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView playerStatDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn statName;
        private System.Windows.Forms.DataGridViewTextBoxColumn statValue;
    }
}