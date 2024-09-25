using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsNetworkCalculator
{
    internal class IP4Subnet
    {
        public IP4Subnet(string ipDezOctet, int cidr)
        {
            IP = new IP4Address(ipDezOctet);
            Netmask = new IP4Netmask(cidr);
            Wildcard = new IP4Address(GetWildcardDez());
            NetId = new IP4Address(GetNetIdDez());
            Broadcast = new IP4Address(GetBroadcastDez());
            HostMin = new IP4Address(GetHostMin(cidr));
            HostMax = new IP4Address(GetHostMax(cidr));
        }

        // auto properties, getters only
        public IP4Address IP { get; }
        public IP4Netmask Netmask { get; }
        public IP4Address Wildcard { get; }
        public IP4Address NetId { get; }
        public IP4Address Broadcast { get; }
        public IP4Address HostMin { get; }
        public IP4Address HostMax { get; }
        public int Cidr 
        {
            get { return Netmask.Cidr; } 
        }
        public uint Hosts 
        { 
            get { return Netmask.Hosts; }
        }

        private uint GetWildcardDez()
        {
            // Bitwise complement operator ~
            // The ~ operator produces a bitwise complement of its operand by reversing each bit
            // unsigned integer (uint) to avoid negative value from ~ operator
            return ~Netmask.Address;
        }

        private uint GetNetIdDez()
        {
            // Logical AND operator &
            // The & operator computes the bitwise logical AND of its integral operands:
            return IP.Address & Netmask.Address;
        }

        private uint GetBroadcastDez()
        {
            // Logical OR operator |
            // The | operator computes the bitwise logical OR of its integral operands:
            return IP.Address | Wildcard.Address;
        }

        private uint GetHostMin(int cidr)
        {
            uint hostMin = NetId.Address + 1;
            if (cidr > 30)
                hostMin = 0;

            return hostMin;
        }
        
        private uint GetHostMax(int cidr)
        {
            uint hostMax = Broadcast.Address - 1;
            if (cidr > 30)
                hostMax = 0;

            return hostMax;
        }
    }
}
