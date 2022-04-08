using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace ClientServerApp
{
    public partial class Form1 : Form
    {
        static int portNumber = 8080;
        Thread ThreadingClient;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        #region [ SERVER  ]

        TcpListener serverSocket;
        TcpClient clientSocket;
        Thread ThreadingServer;
        private void ServerOnButton_Click(object sender, EventArgs e)
        {
            try
            {
                serverSocket = new TcpListener(IPAddress.Parse(textBox1.Text), portNumber);
                ThreadingServer = new Thread(StartServer);
                ThreadingServer.Start();
                ServerOffButton.Enabled = true;
                ServerOnButton.Enabled = false;
                ConnectButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RecieveMessage(string message)
        {
            ServerTextBox.Text += $"{message}. {DateTime.Now}\n";
        }
        
        private void StartServer()
        {
            Action<string> DelegateRecieveMessage = RecieveMessage;
            serverSocket.Start();
            Invoke(DelegateRecieveMessage, $"Сервер включён в {DateTime.Now}. Порт в режиме ожидания соединения...");
            clientSocket = serverSocket.AcceptTcpClient();
            ServerTextBox.Text += $"Клиент подключен с адреса: {(IPEndPoint)clientSocket.Client.RemoteEndPoint} {DateTime.Now}\n";
            SendDrives();
            while (clientSocket.Connected)
            {
                try
                {
                    NetworkStream networkStream = clientSocket.GetStream();
                    byte[] bytesFrom = new byte[1024];
                    networkStream.Read(bytesFrom, 0, 1024);
                    string dataFromClient = Encoding.UTF8.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    if (dataFromClient == "Диски")
                    {
                        SendDrives();
                    }
                    else
					{
                        dataFromClient = dataFromClient.Trim('\0');
						if (Directory.Exists(dataFromClient))
						{
                            SendDirectories(dataFromClient);
						}
                        if (File.Exists(dataFromClient))
						{
                            if (dataFromClient.EndsWith(".txt"))
                            {
                                SendText(dataFromClient);
                            }
							else
							{
                                //
							}
                        }
                    }
                    ServerTextBox.Text += $"Сервер получил сообщение от клиента: {dataFromClient}. {DateTime.Now}\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Invoke(DelegateRecieveMessage, $"Клиент отключился в {DateTime.Now}. Порт в режиме ожидания соединения...");
                    serverSocket.Stop();
                    serverSocket.Start();
                    clientSocket = serverSocket.AcceptTcpClient();
                }
            }
        }
        private void SendDrives()
        {
            string drives = "";
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drives != "")
                    drives += ",";
                drives += drive.Name;
            }
            string message = "Диски: " + drives;
            byte[] listBytes = Encoding.UTF8.GetBytes(message);
            NetworkStream networkStream = clientSocket.GetStream();
            networkStream.Write(listBytes, 0, listBytes.Length);
            networkStream.Flush();
        }
        private void SendDirectories(string path)
		{
            string dirs = "";
            foreach (var item in Directory.GetDirectories(path))
            {
                if (dirs != "")
                    dirs += ",";
                dirs += Path.GetFileName(item);
            }
            foreach (var item in Directory.GetFiles(path))
            {
                if (dirs != "")
                    dirs += ",";
                dirs += Path.GetFileName(item);
            }
            string message = "Каталоги и файлы: " + dirs;
            byte[] listBytes = Encoding.UTF8.GetBytes(message);
            NetworkStream networkStream = clientSocket.GetStream();
            networkStream.Write(listBytes, 0, listBytes.Length);
            networkStream.Flush();
        }
        private async void SendText(string path)
		{
			using (StreamReader streamReader = new StreamReader(path))
			{
                
                string text = await streamReader.ReadToEndAsync();
                string message = "Содержимое текстового файла: " + text;
                byte[] listBytes = Encoding.UTF8.GetBytes(message);
                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Write(listBytes, 0, listBytes.Length);
                networkStream.Flush();
            }
		}
        private void ServerOffButton_Click(object sender, EventArgs e)
        {
            ServerTextBox.Text += $"Сервер отключен {DateTime.Now}\n";
            serverSocket.Stop();
            ThreadingServer.Suspend();
            ServerOnButton.Enabled = true;

            ServerOffButton.Enabled = false;
            DisconnectButton.Enabled = false;
            SendToServerButton.Enabled = false;
            ConnectButton.Enabled = false;
            SendToClientButton.Enabled = false;
        }
        #endregion

        #region [ CLIENT  ]
        TcpClient tcpClient;
        string directory;
        List<string> directories;
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                directories = new List<string>();
                tcpClient = new TcpClient();
                tcpClient.Connect(IPAddress.Parse(textBox1.Text), portNumber);
                ClientTextBox.Text += $"Подключено к серверу! {DateTime.Now}\n";
                ThreadingClient = new Thread(AcceptResponses);
                ThreadingClient.Start();
                DisconnectButton.Enabled = true;
                SendToServerButton.Enabled = true;
                ConnectButton.Enabled = false;
                SendToClientButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AcceptResponses()
        {
            while (tcpClient.Connected)
            {
                try
                {
                    NetworkStream clientStream = tcpClient.GetStream();
                    byte[] bb = new byte[1024];

                    clientStream.Read(bb, 0, 1024);
                    string serverResponse = Encoding.UTF8.GetString(bb);
                    ClientTextBox.Text += $"Клиент получил ответ от сервера: {serverResponse}";
                    ClientTextBox.Text += $" {DateTime.Now}\n";
					if (serverResponse.Contains("Диски: "))
                    {
                        serverResponse = serverResponse.Replace("Диски: ", "");
                        string[] dirs = serverResponse.Split(',');
                        directories.Clear();
                        foreach (string dir in dirs)
                        {
                            directories.Add(dir);
                        }
                        UpdateListBox();
                    }
                    else if (serverResponse.Contains("Каталоги и файлы: "))
                    {
                        serverResponse = serverResponse.Replace("Каталоги и файлы: ", "");
                        string[] dirs = serverResponse.Split(',');
                        directories.Clear();
                        foreach (string dir in dirs)
                        {
                            directories.Add(dir);
                        }
                        UpdateListBox();
                    }
                    else if (serverResponse.Contains("Содержимое текстового файла: "))
					{
                        
                    }
                    else
					{
                        MessageBox.Show("Нераспознанное сообщение с сервера");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void UpdateListBox()
		{
            listBox1.Items.Clear();
			foreach (var item in directories)
			{
                string temp = item.Trim('\0');
                listBox1.Items.Add(temp);
			}
            listBox1.Items.Add(@"C:\Users");
		}
        private void SendToServerButton_Click(object sender, EventArgs e)
        {
            if (directory == null || directory.ToString() == "")
            {
                string path = listBox1.SelectedItem as string;
                directory = path;
            }
            else
            {
                string path = listBox1.SelectedItem.ToString();
                directory = Path.Combine(directory, path);
            }
            SendToServer(directory);
        }
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                tcpClient.Close();
                ThreadingClient.Suspend();
                ClientTextBox.Text += $"Клиент отключен от сервера в {DateTime.Now}\n";
                DisconnectButton.Enabled = false;
                SendToServerButton.Enabled = false;
                ConnectButton.Enabled = true;
                SendToClientButton.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		#endregion
        private void SendToServer(string text)
		{
            try
            {
                string message = text + "$";
                NetworkStream clientStream = tcpClient.GetStream();
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] bytes = encoding.GetBytes(message);
                textBox2.Text = directory;
                ClientTextBox.Text += $"Передача {message.Substring(0, message.IndexOf("$"))} серверу... {DateTime.Now}\n";
                clientStream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		private void pictureBox1_Click(object sender, EventArgs e)
		{
            directory = Path.GetDirectoryName(directory);
            if (directory == null)
                SendToServer("Диски");
            else
                SendToServer(directory);
        }
	}
}
