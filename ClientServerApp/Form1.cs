using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ClientServerApp
{
    public partial class Form1 : Form
    {
        static int portNumber = 8080;
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
            ServerTextBox.Text += $"{message}. {DateTime.Now}\n\n\n\n";
        }
        private void StartServer()
        {
            Action<string> DelegateRecieveMessage = RecieveMessage;
            serverSocket.Start();
            Invoke(DelegateRecieveMessage, $"Сервер включён в {DateTime.Now}. Порт в режиме ожидания соединения...");
            clientSocket = serverSocket.AcceptTcpClient();
            bool disksSent = false;
            while (clientSocket.Connected)
            {
                if (!disksSent)
                {
                    ServerTextBox.Text += $"Клиент подключен с адреса: {(IPEndPoint)clientSocket.Client.RemoteEndPoint} {DateTime.Now}\n\n";
                    SendDrives();
                    disksSent = true;
                }
                try
                {
                    NetworkStream networkStream = clientSocket.GetStream();
                    StreamReader reader = new StreamReader(networkStream);
                    string dataFromClient = reader.ReadLine();

                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    if (dataFromClient == "Диски")
                    {
                        SendDrives();
                        ServerTextBox.Text += $"Сервер получил сообщение от клиента: {dataFromClient}. {DateTime.Now}\n\n";
                    }
                    else if (dataFromClient == "Отключение от сервера:...")
                    {
                        throw new Exception("Клиент отключился");
                    }
                    else
                    {
                        ServerTextBox.Text += $"Сервер получил сообщение от клиента: {dataFromClient}. {DateTime.Now}\n\n";
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
                                StreamWriter writer = new StreamWriter(networkStream);
                                writer.WriteLine("Этот файл распознать нельзя!");
                                writer.Flush();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    disksSent = false;
                    //MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Invoke(DelegateRecieveMessage, $"{ex.Message}. Перезагрузка сервера... {DateTime.Now}. Порт в режиме ожидания соединения..."); serverSocket.Stop();
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
                {
                    drives += ",";
                }

                drives += drive.Name;
            }
            string message = "Диски: " + drives;
            NetworkStream networkStream = clientSocket.GetStream();

            StreamWriter writer = new StreamWriter(networkStream);
            writer.WriteLine(message);
            writer.Flush();
        }
        private void SendDirectories(string path)
        {
            string dirs = "";
            foreach (var item in Directory.GetDirectories(path))
            {
                if (dirs != "")
                {
                    dirs += ",";
                }

                dirs += Path.GetFileName(item);
            }
            foreach (var item in Directory.GetFiles(path))
            {
                if (dirs != "")
                {
                    dirs += ",";
                }

                dirs += Path.GetFileName(item);
            }
            string message = "Каталоги и файлы: " + dirs;

            NetworkStream networkStream = clientSocket.GetStream();
            StreamWriter writer = new StreamWriter(networkStream);
            writer.WriteLine(message);
            writer.Flush();
        }
        private async void SendText(string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {

                string text = await streamReader.ReadToEndAsync();
                string message = "Содержимое текстового файла: " + text;
                byte[] listBytes = Encoding.UTF8.GetBytes(message);
                NetworkStream networkStream = clientSocket.GetStream();
                StreamWriter writer = new StreamWriter(networkStream);
                writer.WriteLine(message);
                writer.Flush();
            }
        }
        private void TurnOffServer()
        {
            if (clientSocket != null)
            {
                NetworkStream networkStream = clientSocket.GetStream();
                StreamWriter writer = new StreamWriter(networkStream);
                writer.WriteLine("Сервер отключен: ");
                writer.Flush();
            }
            serverSocket.Stop();
            ThreadingServer.Suspend();
        }
        private void ServerOffButton_Click(object sender, EventArgs e)
        {
            TurnOffServer();
            ServerTextBox.Text += $"Сервер отключен {DateTime.Now}\n\n";
            ServerOnButton.Enabled = true;
            ServerOffButton.Enabled = false;
            DisconnectButton.Enabled = false;
            ConnectButton.Enabled = false;
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
        }
        #endregion

        #region [ CLIENT  ]
        Thread ThreadingClient;
        TcpClient tcpClient;
        string path;
        List<string> directories;
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                directories = new List<string>();
                tcpClient = new TcpClient();
                tcpClient.Connect(IPAddress.Parse(textBox1.Text), portNumber);
                ClientTextBox.Text += $"Подключено к серверу! {DateTime.Now}\n\n";
                ThreadingClient = new Thread(AcceptResponses);
                ThreadingClient.Start();
                DisconnectButton.Enabled = true;
                pictureBox1.Enabled = true;
                pictureBox2.Enabled = true;
                ConnectButton.Enabled = false;
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
                    StreamReader reader = new StreamReader(clientStream);
                    string serverResponse = reader.ReadLine();

                    if (serverResponse.Contains("Диски: "))
                    {
                        ClientTextBox.Text += $"Клиент получил ответ от сервера: {serverResponse}";
                        ClientTextBox.Text += $" {DateTime.Now}\n\n";
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
                        ClientTextBox.Text += $"Клиент получил ответ от сервера: {serverResponse}";
                        ClientTextBox.Text += $" {DateTime.Now}\n\n";
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
                        ClientTextBox.Text += $"Клиент получил ответ от сервера: {serverResponse}";
                        ClientTextBox.Text += $" {DateTime.Now}\n\n";
                    }
                    else if (serverResponse.Contains("Сервер отключен: "))
                    {
                        ClientTextBox.Text += $"Сервер отключен в {DateTime.Now}\n\n";
                        ThreadingClient.Suspend();
                    }
                    else
                    {
                        ClientTextBox.Text += $"Клиент получил ответ от сервера: {serverResponse}\n\n";
                        ClientTextBox.Text += $" {DateTime.Now}\n\n";
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
        }
        private void SendToServerButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 1)
            {
                if (path == null || path.ToString() == "")
                {
                    string path = listBox1.SelectedItem as string;
                    this.path = path;
                }
                else
                {

                    string path = listBox1.SelectedItem.ToString();
                    this.path = Path.Combine(this.path, path);
                }
                if (Directory.Exists(Path.Combine(path, path)))
                {
                    textBox2.Text = path;
                }
                SendToServer(path);
            }

        }
        private void Disconnect()
        {
            NetworkStream clientStream = tcpClient.GetStream();
            string message = "Отключение от сервера:..." + "$";
            StreamWriter writer = new StreamWriter(clientStream);
            writer.WriteLine(message);
            writer.Flush();
            tcpClient.Close();
            ThreadingClient.Suspend();
        }
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                Disconnect();
                ClientTextBox.Text += $"Клиент отключен от сервера в {DateTime.Now}\n\n";
                DisconnectButton.Enabled = false;
                ConnectButton.Enabled = true;
                pictureBox1.Enabled = false;
                pictureBox2.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SendToServer(string text)
        {
            try
            {
                string message = text + "$";
                NetworkStream clientStream = tcpClient.GetStream();
                ClientTextBox.Text += $"Передача {message.Substring(0, message.IndexOf("$"))} серверу... {DateTime.Now}\n\n";
                StreamWriter writer = new StreamWriter(clientStream);
                writer.WriteLine(message);
                writer.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            path = Path.GetDirectoryName(path);
            if (path == null)
            {
                SendToServer("Диски");
            }
            else
            {
                SendToServer(path);
            }

            textBox2.Text = path;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            path = "";
            SendToServer("Диски");
            textBox2.Text = path;
        }
        #endregion
        private void ExitButton_Click(object sender, EventArgs e)
        {
            TurnOffServer();
            Disconnect();
            Application.Exit();
        }
    }
}
