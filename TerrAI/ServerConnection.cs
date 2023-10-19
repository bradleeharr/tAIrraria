using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace TerrAI
{
    internal class ServerConnection
    {
        private TcpClient _client;
        private NetworkStream _stream;

        public void ConnectToServer()
        {
            try
            {
                Int32 port = 13000;
                _client = new TcpClient("127.0.0.1", port);
                _stream = _client.GetStream();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"ArgumentNullException on Connection: {e}");
            }
            catch (SocketException e)
            {
                Console.WriteLine($"SocketException on Connection: {e}");
            }
        }
        internal async Task SendDataAsync(string data)
        {
            if (_client == null || !_client.Connected)
            {
                ConnectToServer();
            }

            if (_client != null && _client.Connected)
            {
                try
                {
                    byte[] msg = Encoding.ASCII.GetBytes(data);
                    await _stream.WriteAsync(msg, 0, msg.Length);

                    byte[] buffer = new byte[256];
                    int i = await _stream.ReadAsync(buffer, 0, buffer.Length);
                    string command = Encoding.ASCII.GetString(buffer, 0, i);
                    Console.WriteLine($"Received command: {command}");

                    // Execute received command in game here
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Data transmission error: {e}");
                }
            }
        }
    }
}
