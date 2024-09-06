using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsNetworkCalculator
{
    internal class IPv4Subnet : NetAddress32
    {
        public int Cidr {  get; set; }
        public NetAddress32 IPv4 {  get; set; }
        public NetAddress32 Netmask { get; set; }
        public NetAddress32 Wildcard { get; set; }
        public NetAddress32 NetId { get; set; }
        public NetAddress32 Broadcast { get; set; }
        public NetAddress32 HostMin { get; set; }
        public NetAddress32 HostMax { get; set; }
        public uint Hosts { get; set; }
        

        public IPv4Subnet(string ipDezOctet, int cidr)
        {
            IPv4 = new NetAddress32(ipDezOctet);
            Cidr = cidr;
            Netmask = new NetAddress32(GetNetmaskDez(cidr));
            Wildcard = new NetAddress32(GetWildcardDez());
            NetId = new NetAddress32(GetNetIdDez());
            Broadcast = new NetAddress32(GetBroadcastDez());
            HostMin = new NetAddress32(GetHostMin());
            HostMax = new NetAddress32(GetHostMax());
            Hosts = GetHosts();
        }
        // constructor without parameters
        public IPv4Subnet() : this("0.0.0.0", 0) 
        { 
        }

        /// <summary>
        /// Bestimme die Netzmaske aus dem CIDR-Suffix
        /// </summary>
        /// <param name="cidr"></param>
        /// <returns></returns>
        private uint GetNetmaskDez(int cidr)
        {
            uint lDez = 0;
            for (int i = 0; i < 32; i++)
            {
                if (i < cidr)
                    lDez = lDez * 2 + 1;
                else
                    lDez = lDez * 2;
            }
            return lDez;
        }

        private uint GetWildcardDez()
        {
            // Bitwise complement operator ~
            // The ~ operator produces a bitwise complement of its operand by reversing each bit
            //uint wildcard = Convert.ToUInt32(Netmask);      
            // unsigned integer (uint) to avoid negative value from ~ operator
            return ~Netmask.Address;
        }

        private uint GetNetIdDez()
        {
            // Logical AND operator &
            // The & operator computes the bitwise logical AND of its integral operands:
            return IPv4.Address & Netmask.Address;
        }

        private uint GetBroadcastDez()
        {
            // Logical OR operator |
            // The | operator computes the bitwise logical OR of its integral operands:
            return IPv4.Address | Wildcard.Address;
        }

        private uint GetHostMin()
        {
            uint hostMin = NetId.Address + 1;
            if (Cidr > 30)
                hostMin = 0;

            return hostMin;
        }
        
        private uint GetHostMax()
        {
            uint hostMax = Broadcast.Address - 1;
            if (Cidr > 30)
                hostMax = 0;

            return hostMax;
        }

        /// <summary>
        /// Bestimme die Anzahl der Hosts aus dem CIDR-Suffix
        /// </summary>
        /// <param name="cidr"></param>
        /// <returns></returns>
        private uint GetHosts()
        {
            uint hosts = 0;
            if (Cidr < 32)
                hosts = Convert.ToUInt32(Math.Pow(2, 32 - Cidr) - 2);
            return hosts;
        }
    }
}
