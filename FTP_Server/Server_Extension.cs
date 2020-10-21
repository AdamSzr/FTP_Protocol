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

namespace FTP_Server
{
    namespace MyExtension
    {
        public static class exten
        {

            public static bool IsConnected(this Socket socket)
            {
                try
                {
                    return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
                }
                catch (SocketException) { return false; }
            }


            public static string ConvToString(this byte[] value)
            {
                return Encoding.UTF8.GetString(value);
            }
            public static byte[] ConvToByte(this string value)
            {
                return Encoding.UTF8.GetBytes(value);
            }
        }
    }
}
