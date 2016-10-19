using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;

namespace FirstHttpServer
{
    class Server
    {
        HttpWebRequest a = new HttpWebRequest();
        TcpListener server;
        public Server(int i)
        {
            server = new TcpListener(IPAddress.Any, i);
            server.Start();

            while (true)
            {
                TcpClient Client = server.AcceptTcpClient();
                Thread Thread = new Thread(new ParameterizedThreadStart(ClientThread));
                Thread.Start(Client);
                ThreadPool.QueueUserWorkItem(new WaitCallback(ClientThread), server.AcceptTcpClient());
            }
        }

        static void ClientThread(Object StateInfo)
        {
            new Client((TcpClient)StateInfo);
        }

        private void SendError(TcpClient Client, HttpStatusCode Code)
        {
            string CodeStr = Code.ToString() + " " + Code.ToString();

            string Html = "<html><body><h1>" + CodeStr + "</h1></body></html>";
            
            string Str = "HTTP/1.1 " + CodeStr + "\nContent-type: text/html\nContent-Length:" + Html.Length.ToString() + "\n\n" + Html;
            
            byte[] Buffer = Encoding.ASCII.GetBytes(Str);
            
            Client.GetStream().Write(Buffer, 0, Buffer.Length);
            Client.Close();
        }

        ~Server()
        {
            if (server != null)
                server.Stop();
        }
    }
}
