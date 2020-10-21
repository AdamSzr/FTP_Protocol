using System;
using System.Net;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Text.Encodings;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;
using FTP_Server.MyExtension;

namespace FTP_Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            server s = new server();
            await s.Start();
            
        }
    }

    class context
    {
        public int bufferSize = 1024;
        public byte[] data;
        public Socket soc = null;
        public context(Socket client)
        {
            this.data = new byte[this.bufferSize];
            this.soc = client;
        }

    }
    enum Commands
    {
        CDUP=0,
        SMNT=1,
        STOU,
        RMD,
        MKD,
        PWD,
        SYST
    }
    class server
    {
        Socket socket;
        EndPoint ep;
        IPAddress ip;
        int port;
        bool isRunning = false;
        public server(string address = "127.0.0.1", int port = 21)
        {
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.ip = IPAddress.Parse(address);
            this.port = port;
            this.ep = new IPEndPoint(this.ip, this.port);
            this.socket.Bind(this.ep);
            this.socket.Listen(10);
        }
        public async Task Start()
        {
            this.isRunning = true;
            Console.WriteLine("[Server] ON");
            while (isRunning) // pentla akceptujaca
            {
                var clinet = await this.socket.AcceptAsync(); // poczeka na klienta
                var interaction = this.Communicate(clinet); // Hot task
            }
        }
        private Task Communicate(Socket client)
        {
            Console.WriteLine("[Client-Connected] "+client.RemoteEndPoint.ToString());
            return Task.Factory.StartNew(async () =>
            {
                var context = new context(client);
                while(context.soc.IsConnected())
                {
                   
                    var data_recv_counter = await this.Read(context);
                    Console.WriteLine(context.data[0..data_recv_counter].ConvToString());
                }
                Console.WriteLine("[Client-Disconnected] " + client.RemoteEndPoint.ToString());
            },TaskCreationOptions.LongRunning);
        }
        private Task<int> Send(context context)
        {
            return context.soc.SendAsync(context.data, SocketFlags.None);
        }
        private  Task<int> Read(context context)
        {
            return context.soc.ReceiveAsync(context.data, SocketFlags.None);

        }
        public Task Stop()
        {
            return Task.CompletedTask;
        }
    }
}

