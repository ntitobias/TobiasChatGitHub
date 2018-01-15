using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TobiasChattGitHub
{
    //Av Tobias Lindberg 2018-01-15
    //Utifrån  http://csharpskolan.se/article/broadcast-och-chatt

    class Program
    {
        private const int ListenPort = 11000;

        static void Main(string[] args)
        {

        }

        static void Listener()
        {
            UdpClient listener = new UdpClient(ListenPort);

            try
            {
                while (true)
                {
                    IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, ListenPort);
                    byte[] bytes = listener.Receive(ref groupEP);
                    Console.WriteLine("Recieved broadcast from {0} : {1}\n",
                        groupEP.ToString(), Encoding.UTF8.GetString(bytes, 0, bytes.Length));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }
    }
}
