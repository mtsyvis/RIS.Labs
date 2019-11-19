using System;

namespace Lab2.Client
{
    using System.Net.Sockets;
    using System.Runtime.Serialization.Formatters.Binary;

    using Lab2.Models;

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
            _client = new TcpClient(address, port);
            _stream = _client.GetStream();
            _formatter = new BinaryFormatter();
        }

        public void Connect()
        {
            _client = new TcpClient(address, port);
            _stream = _client.GetStream();
        }

        public static ClientConnection Instance => _instance.Value;

        public void Send(Message message)
        {
            _formatter.Serialize(_stream, message);
            this._stream.Flush();
        }

        public Message ReceiveMessage()
        {
            return (Message)_formatter.Deserialize(_stream);
        }
    }
}
