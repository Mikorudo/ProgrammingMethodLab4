
namespace ClientServerApp
{
    partial class ClientServerInterface
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientServerInterface));
            this.ipLabel = new System.Windows.Forms.Label();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ServerOffButton = new System.Windows.Forms.Button();
            this.ServerOnButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ClientTextBox = new System.Windows.Forms.RichTextBox();
            this.ServerTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.backBtn = new System.Windows.Forms.PictureBox();
            this.drivesBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.backBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drivesBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(7, 427);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(64, 17);
            this.ipLabel.TabIndex = 32;
            this.ipLabel.Text = "IP-адрес";
            // 
            // ipBox
            // 
            this.ipBox.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.ipBox.Location = new System.Drawing.Point(77, 424);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(293, 22);
            this.ipBox.TabIndex = 31;
            this.ipBox.Text = "127.0.0.1";
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(7, 526);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(363, 30);
            this.ExitButton.TabIndex = 29;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ServerOffButton
            // 
            this.ServerOffButton.Enabled = false;
            this.ServerOffButton.Location = new System.Drawing.Point(7, 490);
            this.ServerOffButton.Name = "ServerOffButton";
            this.ServerOffButton.Size = new System.Drawing.Size(156, 30);
            this.ServerOffButton.TabIndex = 28;
            this.ServerOffButton.Text = "Отключить сервер";
            this.ServerOffButton.UseVisualStyleBackColor = true;
            this.ServerOffButton.Click += new System.EventHandler(this.ServerOffButton_Click);
            // 
            // ServerOnButton
            // 
            this.ServerOnButton.Location = new System.Drawing.Point(7, 452);
            this.ServerOnButton.Name = "ServerOnButton";
            this.ServerOnButton.Size = new System.Drawing.Size(156, 30);
            this.ServerOnButton.TabIndex = 27;
            this.ServerOnButton.Text = "Включить сервер";
            this.ServerOnButton.UseVisualStyleBackColor = true;
            this.ServerOnButton.Click += new System.EventHandler(this.ServerOnButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(451, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Клиентная сторона";
            // 
            // ClientTextBox
            // 
            this.ClientTextBox.Location = new System.Drawing.Point(376, 23);
            this.ClientTextBox.Name = "ClientTextBox";
            this.ClientTextBox.ReadOnly = true;
            this.ClientTextBox.Size = new System.Drawing.Size(303, 530);
            this.ClientTextBox.TabIndex = 25;
            this.ClientTextBox.Text = "";
            // 
            // ServerTextBox
            // 
            this.ServerTextBox.Location = new System.Drawing.Point(692, 23);
            this.ServerTextBox.Name = "ServerTextBox";
            this.ServerTextBox.ReadOnly = true;
            this.ServerTextBox.Size = new System.Drawing.Size(303, 530);
            this.ServerTextBox.TabIndex = 33;
            this.ServerTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(789, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "Серверная сторона";
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Enabled = false;
            this.DisconnectButton.Location = new System.Drawing.Point(169, 490);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(201, 30);
            this.DisconnectButton.TabIndex = 36;
            this.DisconnectButton.Text = "Отключиться от сервера";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Enabled = false;
            this.ConnectButton.Location = new System.Drawing.Point(169, 452);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(201, 30);
            this.ConnectButton.TabIndex = 35;
            this.ConnectButton.Text = "Подключиться к серверу";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(7, 55);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(363, 356);
            this.listBox.TabIndex = 39;
            this.listBox.DoubleClick += new System.EventHandler(this.SendToServerButton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Enabled = false;
            this.pathTextBox.Location = new System.Drawing.Point(77, 23);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(293, 22);
            this.pathTextBox.TabIndex = 40;
            // 
            // backBtn
            // 
            this.backBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBtn.Enabled = false;
            this.backBtn.Image = ((System.Drawing.Image)(resources.GetObject("backBtn.Image")));
            this.backBtn.Location = new System.Drawing.Point(42, 23);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(29, 22);
            this.backBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backBtn.TabIndex = 41;
            this.backBtn.TabStop = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // drivesBtn
            // 
            this.drivesBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drivesBtn.Enabled = false;
            this.drivesBtn.Image = ((System.Drawing.Image)(resources.GetObject("drivesBtn.Image")));
            this.drivesBtn.Location = new System.Drawing.Point(7, 23);
            this.drivesBtn.Name = "drivesBtn";
            this.drivesBtn.Size = new System.Drawing.Size(29, 22);
            this.drivesBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.drivesBtn.TabIndex = 42;
            this.drivesBtn.TabStop = false;
            this.drivesBtn.Click += new System.EventHandler(this.drivesBtn_Click);
            // 
            // ClientServerInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 565);
            this.Controls.Add(this.drivesBtn);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ServerTextBox);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.ipBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ServerOffButton);
            this.Controls.Add(this.ServerOnButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClientTextBox);
            this.Name = "ClientServerInterface";
            this.Text = "Клиенто-программное приложение";
            ((System.ComponentModel.ISupportInitialize)(this.backBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drivesBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ServerOffButton;
        private System.Windows.Forms.Button ServerOnButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox ClientTextBox;
        private System.Windows.Forms.RichTextBox ServerTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Button ConnectButton;
		private System.Windows.Forms.ListBox listBox;
		private System.Windows.Forms.TextBox pathTextBox;
		private System.Windows.Forms.PictureBox backBtn;
        private System.Windows.Forms.PictureBox drivesBtn;
    }
}

