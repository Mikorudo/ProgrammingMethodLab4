
namespace ClientServerApp
{
    partial class Form1
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
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SendToClientButton = new System.Windows.Forms.Button();
			this.ExitButton = new System.Windows.Forms.Button();
			this.ServerOffButton = new System.Windows.Forms.Button();
			this.ServerOnButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.ClientTextBox = new System.Windows.Forms.RichTextBox();
			this.ServerTextBox = new System.Windows.Forms.RichTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SendToServerButton = new System.Windows.Forms.Button();
			this.DisconnectButton = new System.Windows.Forms.Button();
			this.ConnectButton = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 391);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 17);
			this.label3.TabIndex = 32;
			this.label3.Text = "IP-адрес";
			// 
			// textBox1
			// 
			this.textBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
			this.textBox1.Location = new System.Drawing.Point(77, 388);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(293, 22);
			this.textBox1.TabIndex = 31;
			this.textBox1.Text = "127.0.0.1";
			// 
			// SendToClientButton
			// 
			this.SendToClientButton.Enabled = false;
			this.SendToClientButton.Location = new System.Drawing.Point(7, 490);
			this.SendToClientButton.Name = "SendToClientButton";
			this.SendToClientButton.Size = new System.Drawing.Size(156, 30);
			this.SendToClientButton.TabIndex = 30;
			this.SendToClientButton.Text = "Передать клиенту";
			this.SendToClientButton.UseVisualStyleBackColor = true;
			// 
			// ExitButton
			// 
			this.ExitButton.Location = new System.Drawing.Point(7, 526);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.Size = new System.Drawing.Size(363, 30);
			this.ExitButton.TabIndex = 29;
			this.ExitButton.Text = "Выход";
			this.ExitButton.UseVisualStyleBackColor = true;
			// 
			// ServerOffButton
			// 
			this.ServerOffButton.Enabled = false;
			this.ServerOffButton.Location = new System.Drawing.Point(7, 454);
			this.ServerOffButton.Name = "ServerOffButton";
			this.ServerOffButton.Size = new System.Drawing.Size(156, 30);
			this.ServerOffButton.TabIndex = 28;
			this.ServerOffButton.Text = "Отключить сервер";
			this.ServerOffButton.UseVisualStyleBackColor = true;
			this.ServerOffButton.Click += new System.EventHandler(this.ServerOffButton_Click);
			// 
			// ServerOnButton
			// 
			this.ServerOnButton.Location = new System.Drawing.Point(7, 416);
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
			// SendToServerButton
			// 
			this.SendToServerButton.Enabled = false;
			this.SendToServerButton.Location = new System.Drawing.Point(169, 490);
			this.SendToServerButton.Name = "SendToServerButton";
			this.SendToServerButton.Size = new System.Drawing.Size(201, 30);
			this.SendToServerButton.TabIndex = 38;
			this.SendToServerButton.Text = "Передать серверу";
			this.SendToServerButton.UseVisualStyleBackColor = true;
			this.SendToServerButton.Click += new System.EventHandler(this.SendToServerButton_Click);
			// 
			// DisconnectButton
			// 
			this.DisconnectButton.Enabled = false;
			this.DisconnectButton.Location = new System.Drawing.Point(169, 454);
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
			this.ConnectButton.Location = new System.Drawing.Point(169, 416);
			this.ConnectButton.Name = "ConnectButton";
			this.ConnectButton.Size = new System.Drawing.Size(201, 30);
			this.ConnectButton.TabIndex = 35;
			this.ConnectButton.Text = "Подключиться к серверу";
			this.ConnectButton.UseVisualStyleBackColor = true;
			this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Location = new System.Drawing.Point(7, 23);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(363, 356);
			this.listBox1.TabIndex = 39;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1007, 565);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.SendToServerButton);
			this.Controls.Add(this.DisconnectButton);
			this.Controls.Add(this.ConnectButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ServerTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.SendToClientButton);
			this.Controls.Add(this.ExitButton);
			this.Controls.Add(this.ServerOffButton);
			this.Controls.Add(this.ServerOnButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ClientTextBox);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button SendToClientButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ServerOffButton;
        private System.Windows.Forms.Button ServerOnButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox ClientTextBox;
        private System.Windows.Forms.RichTextBox ServerTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SendToServerButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Button ConnectButton;
		private System.Windows.Forms.ListBox listBox1;
	}
}

