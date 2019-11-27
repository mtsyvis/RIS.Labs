using System;
using System.Threading.Tasks;

namespace Lab2.Server
{
    using System.Net.Sockets;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Forms;

    using Message = Lab2.Models.Message;

    public class ClientHandler
    {
        private TcpClient _client;

        private BinaryFormatter _formatter;

        private NetworkStream _stream;

        public ClientHandler(TcpClient tcpClient, TextBox logger)
        {
            _client = tcpClient;
            _stream = _client.GetStream();
            _formatter = new BinaryFormatter();
        }

        public async void ProcessAsync()
        {
            try
            {
                var requestHandler = new RequestHandler();

                while (this._client.Connected)
                {
                    var request = (Message)_formatter.Deserialize(_stream);

                    ServerLogger.LogMessage($"Client: {_client.GetHashCode()}, request: {request.Type.ToString()}");

                    object response = requestHandler.HandleRequest(request);

                    await this.Send(response);
                }
            }
            catch (SocketException ex)
            {
                ServerLogger.LogMessage($"Client: {this._client.GetHashCode()} disconnected");
            }
            catch (Exception ex)
            {
                ServerLogger.LogException(ex);
            }
            finally
            {
                _stream?.Close();
                _client?.Close();
            }
        }

        private async Task Send(object response)
        {
            if (response is null)
            {
                return;
            }

            this._formatter.Serialize(this._stream, response);
            await this._stream.FlushAsync();
            ServerLogger.LogMessage($"Send: {response.ToString()}");
        }
    }
}
