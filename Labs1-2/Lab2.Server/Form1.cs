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
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void StartServer_Click(object sender, EventArgs e)
        {
            var serverWorkThread = new Thread(new ThreadStart(this.StartServer));

            serverWorkThread.Start();

            var button = (Button)sender;
            button.Enabled = false;
        }

        private void StartServer()
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse(IpAddress), Port);
                listener.Start();

                ServerLogger.LogMessage("Wait connection...");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();//.ConfigureAwait(false);
                    ServerLogger.LogMessage($"Client {client.GetHashCode()} connected.");

                    ClientHandler clientHandler = new ClientHandler(client, this.serverLog);

                    var clientThread = new Thread(clientHandler.ProcessAsync);
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                this.serverLog.AppendText(ex.Message);
            }
            finally
            {
                listener?.Stop();
            }
        }
    }
}
