namespace ToriLobby
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gameRoomList = new System.Windows.Forms.DataGridView();
            this.RoomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GameMod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerList = new System.Windows.Forms.ListBox();
            this.LobbyStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripTotalLobbies = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripTotalPlayers = new System.Windows.Forms.ToolStripStatusLabel();
            this.serversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainFormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.tableLayoutServerBrowser = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gameRoomList)).BeginInit();
            this.LobbyStatusStrip.SuspendLayout();
            this.MainFormMenuStrip.SuspendLayout();
            this.tableLayoutServerBrowser.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameRoomList
            // 
            this.gameRoomList.AllowUserToAddRows = false;
            this.gameRoomList.AllowUserToDeleteRows = false;
            this.gameRoomList.AllowUserToResizeRows = false;
            this.gameRoomList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gameRoomList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.gameRoomList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameRoomList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gameRoomList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomName,
            this.RoomDesc,
            this.GameMod,
            this.IPAddress,
            this.Port,
            this.PlayerCount});
            this.gameRoomList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameRoomList.Location = new System.Drawing.Point(3, 2);
            this.gameRoomList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gameRoomList.MultiSelect = false;
            this.gameRoomList.Name = "gameRoomList";
            this.gameRoomList.ReadOnly = true;
            this.gameRoomList.RowHeadersVisible = false;
            this.gameRoomList.RowTemplate.Height = 28;
            this.gameRoomList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gameRoomList.Size = new System.Drawing.Size(1010, 488);
            this.gameRoomList.TabIndex = 0;
            this.gameRoomList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gameRoomList_CellClick);
            // 
            // RoomName
            // 
            this.RoomName.HeaderText = "Name";
            this.RoomName.Name = "RoomName";
            this.RoomName.ReadOnly = true;
            // 
            // RoomDesc
            // 
            this.RoomDesc.HeaderText = "Description";
            this.RoomDesc.Name = "RoomDesc";
            this.RoomDesc.ReadOnly = true;
            // 
            // GameMod
            // 
            this.GameMod.HeaderText = "Mod";
            this.GameMod.Name = "GameMod";
            this.GameMod.ReadOnly = true;
            // 
            // IPAddress
            // 
            this.IPAddress.HeaderText = "IP";
            this.IPAddress.Name = "IPAddress";
            this.IPAddress.ReadOnly = true;
            // 
            // Port
            // 
            this.Port.HeaderText = "Port";
            this.Port.Name = "Port";
            this.Port.ReadOnly = true;
            // 
            // PlayerCount
            // 
            this.PlayerCount.HeaderText = "Players";
            this.PlayerCount.Name = "PlayerCount";
            this.PlayerCount.ReadOnly = true;
            // 
            // PlayerList
            // 
            this.PlayerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerList.FormattingEnabled = true;
            this.PlayerList.ItemHeight = 16;
            this.PlayerList.Location = new System.Drawing.Point(1019, 2);
            this.PlayerList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PlayerList.Name = "PlayerList";
            this.PlayerList.Size = new System.Drawing.Size(211, 488);
            this.PlayerList.TabIndex = 1;
            // 
            // LobbyStatusStrip
            // 
            this.LobbyStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.LobbyStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTotalLobbies,
            this.toolStripTotalPlayers});
            this.LobbyStatusStrip.Location = new System.Drawing.Point(0, 520);
            this.LobbyStatusStrip.Name = "LobbyStatusStrip";
            this.LobbyStatusStrip.Size = new System.Drawing.Size(1233, 25);
            this.LobbyStatusStrip.TabIndex = 4;
            this.LobbyStatusStrip.Text = "Lobby Status";
            // 
            // toolStripTotalLobbies
            // 
            this.toolStripTotalLobbies.Name = "toolStripTotalLobbies";
            this.toolStripTotalLobbies.Size = new System.Drawing.Size(76, 20);
            this.toolStripTotalLobbies.Text = "Lobbies: 0";
            // 
            // toolStripTotalPlayers
            // 
            this.toolStripTotalPlayers.Name = "toolStripTotalPlayers";
            this.toolStripTotalPlayers.Size = new System.Drawing.Size(70, 20);
            this.toolStripTotalPlayers.Text = "Players: 0";
            // 
            // serversToolStripMenuItem
            // 
            this.serversToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.serversToolStripMenuItem.Name = "serversToolStripMenuItem";
            this.serversToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.serversToolStripMenuItem.Text = "Rooms";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // MainFormMenuStrip
            // 
            this.MainFormMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serversToolStripMenuItem});
            this.MainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainFormMenuStrip.Name = "MainFormMenuStrip";
            this.MainFormMenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.MainFormMenuStrip.Size = new System.Drawing.Size(1233, 28);
            this.MainFormMenuStrip.TabIndex = 3;
            this.MainFormMenuStrip.Text = "menuStrip1";
            // 
            // tableLayoutServerBrowser
            // 
            this.tableLayoutServerBrowser.ColumnCount = 2;
            this.tableLayoutServerBrowser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutServerBrowser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 217F));
            this.tableLayoutServerBrowser.Controls.Add(this.gameRoomList, 0, 0);
            this.tableLayoutServerBrowser.Controls.Add(this.PlayerList, 1, 0);
            this.tableLayoutServerBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutServerBrowser.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutServerBrowser.Name = "tableLayoutServerBrowser";
            this.tableLayoutServerBrowser.RowCount = 1;
            this.tableLayoutServerBrowser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutServerBrowser.Size = new System.Drawing.Size(1233, 492);
            this.tableLayoutServerBrowser.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1233, 545);
            this.Controls.Add(this.tableLayoutServerBrowser);
            this.Controls.Add(this.LobbyStatusStrip);
            this.Controls.Add(this.MainFormMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainFormMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "ToriLobby";
            ((System.ComponentModel.ISupportInitialize)(this.gameRoomList)).EndInit();
            this.LobbyStatusStrip.ResumeLayout(false);
            this.LobbyStatusStrip.PerformLayout();
            this.MainFormMenuStrip.ResumeLayout(false);
            this.MainFormMenuStrip.PerformLayout();
            this.tableLayoutServerBrowser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gameRoomList;
        private System.Windows.Forms.ListBox PlayerList;
        private System.Windows.Forms.StatusStrip LobbyStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripTotalPlayers;
        private System.Windows.Forms.ToolStripStatusLabel toolStripTotalLobbies;
        private System.Windows.Forms.ToolStripMenuItem serversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.MenuStrip MainFormMenuStrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameMod;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerCount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutServerBrowser;
    }
}

