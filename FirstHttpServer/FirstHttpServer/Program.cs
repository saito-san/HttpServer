using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace FirstHttpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server(8080);
            
            int MaxThreads = Environment.ProcessorCount * 8;
            ThreadPool.SetMaxThreads(MaxThreads, MaxThreads);
            ThreadPool.SetMinThreads(2, 2);
        }
    }
}
