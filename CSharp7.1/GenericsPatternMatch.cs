using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp7._1
{
    class GenericsPatternMatch
    {
//#if CSharp_71
        public class Packet
        {
        }

        public class KeepalivePacket : Packet
        {
        }

        public void Send<T>(T packet)
            where T : Packet
        {
            if (packet is KeepalivePacket keepalive)
            {
                // Do stuff with keepalive
            }

            switch (packet)
            {
                case KeepalivePacket keepalivePacket:
                    // Do stuff with keepalivePacket
                    break;
            }
        }
//#endif
    }

}
