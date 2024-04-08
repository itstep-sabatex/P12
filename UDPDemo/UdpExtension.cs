using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UDPDemo
{
    public static class UdpExtension
    {
        public static (byte[] data, IPEndPoint ip) Receive(this UdpClient udpClient)
        {
            var ip = new IPEndPoint(IPAddress.Any, 5000);
            var data = udpClient.Receive(ref ip);
            return (data, ip);

        }

    }
}
