using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace FirstHttpServer
{
    class Client
    {
        public string request;
        
        public byte[] buffer;



        TcpClient client;

        public Client()
        {
            client = new TcpClient();
        }

        public Client(TcpClient Client)
        {
            request = "";

            buffer = new byte[];
            
                
        }
    }
}
