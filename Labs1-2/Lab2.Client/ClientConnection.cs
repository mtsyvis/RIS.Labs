using System;

namespace Lab2.Client
{
    using System.Net.Sockets;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Forms;

    using Message = Lab2.Models.Message;

    public sealed class ClientConnection
    {
        private const int port = 8080;

        private const string address = "127.0.0.1";

        private TcpClient _client;

        private NetworkStream _stream;

        private BinaryFormatter _formatter;

        private static readonly Lazy<ClientConnection> _instance = new Lazy<ClientConnection>(() => new ClientConnection());

        private ClientConnection()
        {
            _formatter = new BinaryFormatter();
            this.Connect();
        }

        private void Connect()
        {
           // if (this._client != null && this._client.Connected) return;

            this._client = new TcpClient(address, port);
            this._stream = this._client.GetStream();
        }

        public static ClientConnection Instance => _instance.Value;

        public void Send(Message message)
        {
            if (!this._client.Connected)
            {
                MessageBox.Show("Server is not running!");
            }

            _formatter.Serialize(_stream, message);
            this._stream.Flush();
        }

        public Message ReceiveMessage()
        {
            if (!this._client.Connected)
            {
                MessageBox.Show("Server is not running!");
            }

            return (Message)_formatter.Deserialize(_stream);
        }
    }
}
