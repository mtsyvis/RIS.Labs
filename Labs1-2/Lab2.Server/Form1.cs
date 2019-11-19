using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Lab2.Server
{
    public partial class Form1 : Form
    {
        private const string IpAddress = "127.0.0.1";

        private const int Port = 8080;

        private static TcpListener listener;

        public Form1()
        {
            InitializeComponent();
            ServerLogger.LoggerBox = this.serverLog;
        }

        private void StartServer_Click(object sender, EventArgs e)
        {
            var serverWorkThread = new Thread(new ThreadStart(this.StartServer));
            //Task.Run(this.StartServer).Wait();

            serverWorkThread.Start();

            var button = (Button)sender;
            button.Enabled = false;
        }

        private async void StartServer()
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse(IpAddress), Port);
                listener.Start();

                //this.serverLog.AppendText("Wait connection...");
                ServerLogger.LogMessage("Wait connection...");

                while (true)
                {
                    TcpClient client = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
                    //this.serverLog.AppendText($"Client connected. Socket info: {client.Client.ToString()}");
                    ServerLogger.LogMessage($"Client connected. Socket info: {client.Client.ToString()}\n");

                    ClientHandler clientHandler = new ClientHandler(client, this.serverLog);
                    clientHandler.ProcessAsync();

                    //Thread clientThread = new Thread(new ThreadStart(clientHandler.ProcessAsync));
                    //clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                this.serverLog.AppendText(ex.Message);
                //ServerLogger.LogMessage(ex.Message);
            }
            finally
            {
                listener?.Stop();
            }
        }
    }
}
