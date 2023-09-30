using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main()
    {
        TcpListener server = null;
        try
        {
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(localAddr, port);
            server.Start();

            while (true)
            {
                Console.Write("Waiting for a connection... ");
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[256];
                int i;

                while ((i = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string received = Encoding.ASCII.GetString(buffer, 0, i);
                    Console.WriteLine($"Received: {received}");

                    // Process data and send command back
                    string command = "MoveRight"; // Replace with actual command
                    byte[] msg = Encoding.ASCII.GetBytes(command);
                    stream.Write(msg, 0, msg.Length);
                }

                client.Close();
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine($"SocketException: {e}");
        }
        finally
        {
            server.Stop();
        }
    }
}
