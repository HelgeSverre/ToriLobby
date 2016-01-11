namespace ToriLobby
{
    partial class BotForm
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
            this.BotFormLayout = new System.Windows.Forms.TableLayoutPanel();
            this.playerList = new System.Windows.Forms.ListBox();
            this.txtRoomChatBox = new System.Windows.Forms.RichTextBox();
            this.txtMessageArea = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.BotFormLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // BotFormLayout
            // 
            this.BotFormLayout.ColumnCount = 2;
            this.BotFormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.08847F));
            this.BotFormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.91153F));
            this.BotFormLayout.Controls.Add(this.playerList, 1, 0);
            this.BotFormLayout.Controls.Add(this.txtRoomChatBox, 0, 0);
            this.BotFormLayout.Controls.Add(this.txtMessageArea, 0, 1);
            this.BotFormLayout.Controls.Add(this.btnSendMessage, 1, 1);
            this.BotFormLayout.Location = new System.Drawing.Point(12, 12);
            this.BotFormLayout.Name = "BotFormLayout";
            this.BotFormLayout.RowCount = 2;
            this.BotFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BotFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.BotFormLayout.Size = new System.Drawing.Size(633, 607);
            this.BotFormLayout.TabIndex = 0;
            // 
            // playerList
            // 
            this.playerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerList.FormattingEnabled = true;
            this.playerList.ItemHeight = 16;
            this.playerList.Location = new System.Drawing.Point(434, 3);
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(196, 565);
            this.playerList.TabIndex = 0;
            // 
            // txtRoomChatBox
            // 
            this.txtRoomChatBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRoomChatBox.Location = new System.Drawing.Point(3, 3);
            this.txtRoomChatBox.Name = "txtRoomChatBox";
            this.txtRoomChatBox.Size = new System.Drawing.Size(425, 565);
            this.txtRoomChatBox.TabIndex = 1;
            this.txtRoomChatBox.Text = "";
            // 
            // txtMessageArea
            // 
            this.txtMessageArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessageArea.Location = new System.Drawing.Point(3, 574);
            this.txtMessageArea.Multiline = true;
            this.txtMessageArea.Name = "txtMessageArea";
            this.txtMessageArea.Size = new System.Drawing.Size(425, 30);
            this.txtMessageArea.TabIndex = 2;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSendMessage.Location = new System.Drawing.Point(434, 574);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(196, 30);
            this.btnSendMessage.TabIndex = 3;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            // 
            // BotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 627);
            this.Controls.Add(this.BotFormLayout);
            this.Name = "BotForm";
            this.ShowIcon = false;
            this.Text = "Room Manager";
            this.BotFormLayout.ResumeLayout(false);
            this.BotFormLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel BotFormLayout;
        private System.Windows.Forms.ListBox playerList;
        private System.Windows.Forms.RichTextBox txtRoomChatBox;
        private System.Windows.Forms.TextBox txtMessageArea;
        private System.Windows.Forms.Button btnSendMessage;
    }
}