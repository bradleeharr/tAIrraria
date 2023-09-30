using Microsoft.Xna.Framework.Graphics;
using System;
using System.Net.Sockets;
using System.Text;
using Terraria.Chat.Commands;
using Terraria.ModLoader;

namespace TerrAI
{
    public class TerrAI : Mod
    {
        public override void Load()
        {
            StartClient();
        }

        public void StartClient()
        {
            try
            {
                Int32 port = 13000;
                TcpClient client = new TcpClient("127.0.0.1", port);

                NetworkStream stream = client.GetStream();

                // Send data to server
                string data = "GameData"; // Replace with actual game data
                byte[] msg = Encoding.ASCII.GetBytes(data);
                stream.Write(msg, 0, msg.Length);
                
                // Receive command from server
                byte[] buffer = new byte[256];
                int i = stream.Read(buffer, 0, buffer.Length);
                string command = Encoding.ASCII.GetString(buffer, 0, i);
                Console.WriteLine($"Received command: {command}");

                // Execute received command in game here

                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"ArgumentNullException: {e}");
            }
            catch (SocketException e)
            {
                Console.WriteLine($"SocketException: {e}");
            }
        }
    }
}